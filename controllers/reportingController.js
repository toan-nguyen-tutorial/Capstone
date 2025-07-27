const MotorLog = require('../models/MotorLog');
const ValveLog = require('../models/ValveLog');
const DamperLog = require('../models/DamperLog');
const puppeteer = require('puppeteer');
const ejs = require('ejs');
const path = require('path');
const fs = require('fs');

// Render reporting page
exports.getReporting = (req, res) => {
  res.render('reporting', { user: res.locals.user });
};

// ===== MOTOR RUNTIME REPORTING APIs =====

/**
 * API 1: Thời gian hoạt động theo ngày
 * GET /api/reporting/motor-runtime/daily
 * Query: startDate, endDate, motorName (optional), groupBy (day/week/month)
 */
exports.getMotorRuntimeDaily = async (req, res) => {
  try {
    const { startDate, endDate, motorName, groupBy = 'day' } = req.query;
    
    // Validate input
    if (!startDate || !endDate) {
      return res.status(400).json({
        success: false,
        message: 'startDate and endDate are required'
      });
    }

    // Parse dates
    const start = new Date(startDate);
    const end = new Date(endDate);
    
    // Build query
    const query = {
      timestamp: { $gte: start, $lte: end },
      RunFeedback: true
    };
    
    if (motorName) {
      query.name = motorName;
    }

    // Determine date format based on groupBy
    let dateFormat;
    let dateField;
    
    switch (groupBy) {
      case 'week':
        dateFormat = "%Y-W%U"; // Year-Week
        dateField = "week";
        break;
      case 'month':
        dateFormat = "%Y-%m"; // Year-Month
        dateField = "month";
        break;
      default: // day
        dateFormat = "%Y-%m-%d"; // Year-Month-Day
        dateField = "date";
        break;
    }

    // MongoDB aggregation pipeline - tạo pipeline động
    const pipeline = [
      { $match: query },
      {
        $group: {
          _id: {
            [dateField]: { $dateToString: { format: dateFormat, date: "$timestamp" } },
            motorName: "$name"
          },
          runtimeSeconds: { $sum: 1 }, // Đếm số record = số giây hoạt động
          runtimeMinutes: { $sum: 1 },
          runtimeHours: { $sum: 1 }
        }
      }
    ];
    
    // Thêm group stage động dựa trên dateField
    const groupStage = {
      $group: {
        _id: {},
        motors: {
          $push: {
            motorName: "$_id.motorName",
            runtimeSeconds: "$runtimeSeconds",
            runtimeMinutes: { $divide: ["$runtimeMinutes", 60] },
            runtimeHours: { $divide: ["$runtimeHours", 3600] },
            runtimeFormatted: {
              $concat: [
                { $toString: { $floor: { $divide: ["$runtimeHours", 3600] } } },
                ":",
                { $toString: { $floor: { $mod: [{ $divide: ["$runtimeMinutes", 60] }, 60] } } },
                ":",
                { $toString: { $floor: { $mod: ["$runtimeSeconds", 60] } } }
              ]
            }
          }
        }
      }
    };
    
    // Set _id dựa trên dateField
    if (dateField === 'week') {
      groupStage.$group._id = "$_id.week";
    } else if (dateField === 'month') {
      groupStage.$group._id = "$_id.month";
    } else {
      groupStage.$group._id = "$_id.date";
    }
    
    pipeline.push(groupStage);
    pipeline.push({ $sort: { _id: 1 } });

    const result = await MotorLog.aggregate(pipeline);

    // Format response
    const formattedResult = result.map(period => ({
      [dateField]: period._id,
      motors: Array.isArray(period.motors) ? period.motors.reduce((acc, motor) => {
        acc[motor.motorName] = {
          runtime: motor.runtimeSeconds,
          runtimeFormatted: motor.runtimeFormatted,
          percentage: calculatePercentage(motor.runtimeSeconds, groupBy)
        };
        return acc;
      }, {}) : {}
    }));

    res.json({
      success: true,
      data: {
        dailyChart: formattedResult,
        summary: {
          totalPeriods: result.length,
          averageRuntime: calculateAverageRuntime(formattedResult),
          groupBy: groupBy
        }
      }
    });

  } catch (error) {
    console.error('Error in getMotorRuntimeDaily:', error);
    res.status(500).json({
      success: false,
      message: 'Internal server error'
    });
  }
};

/**
 * API 2: So sánh thời gian hoạt động giữa các motor
 * GET /api/reporting/motor-runtime/comparison
 * Query: startDate, endDate, groupBy (day/week/month)
 */
exports.getMotorRuntimeComparison = async (req, res) => {
  try {
    const { startDate, endDate, groupBy = 'day' } = req.query;
    
    if (!startDate || !endDate) {
      return res.status(400).json({
        success: false,
        message: 'startDate and endDate are required'
      });
    }

    const start = new Date(startDate);
    const end = new Date(endDate);

    // Calculate total time span in seconds
    const totalTimeSpan = (end - start) / 1000;

    // Aggregation pipeline cho so sánh motor
    const pipeline = [
      {
        $match: {
          timestamp: { $gte: start, $lte: end },
          RunFeedback: true
        }
      },
      {
        $group: {
          _id: "$name",
          totalRuntime: { $sum: 1 }, // Số giây hoạt động
          totalRecords: { $sum: 1 },
          firstSeen: { $min: "$timestamp" },
          lastSeen: { $max: "$timestamp" }
        }
      },
      {
        $addFields: {
          runtimeMinutes: { $divide: ["$totalRuntime", 60] },
          runtimeHours: { $divide: ["$totalRuntime", 3600] },
          runtimeFormatted: {
            $concat: [
              { $toString: { $floor: { $divide: ["$totalRuntime", 3600] } } },
              ":",
              { $toString: { $floor: { $mod: [{ $divide: ["$totalRuntime", 60] }, 60] } } },
              ":",
              { $toString: { $floor: { $mod: ["$totalRuntime", 60] } } }
            ]
          },
          efficiency: {
            $multiply: [
              { $divide: ["$totalRuntime", totalTimeSpan] },
              100
            ]
          }
        }
      },
      { $sort: { totalRuntime: -1 } }
    ];

    const result = await MotorLog.aggregate(pipeline);

    // Format response
    const totalDays = Math.max(1, Math.ceil((end - start) / (1000 * 60 * 60 * 24)));
    const motorComparison = result.map(motor => ({
      motorName: motor._id,
      totalRuntime: motor.totalRuntime,
      runtimeFormatted: motor.runtimeFormatted,
      efficiency: (totalTimeSpan > 0 ? motor.efficiency.toFixed(1) : 0),
      averageDailyRuntime: (totalDays > 0 ? (motor.runtimeHours / totalDays).toFixed(1) : 0)
    }));

    res.json({
      success: true,
      data: {
        motorComparison,
        summary: {
          totalMotors: result.length,
          averageEfficiency: (result.length > 0 ? (result.reduce((sum, m) => sum + m.efficiency, 0) / result.length).toFixed(1) : 0),
          mostActiveMotor: result[0]?.motorName || null,
          leastActiveMotor: result[result.length - 1]?.motorName || null,
          groupBy: groupBy
        }
      }
    });

  } catch (error) {
    console.error('Error in getMotorRuntimeComparison:', error);
    res.status(500).json({
      success: false,
      message: 'Internal server error'
    });
  }
};

/**
 * API 3: Thống kê tổng hợp
 * GET /api/reporting/motor-runtime/summary
 * Query: startDate, endDate, groupBy (day/week/month)
 */
exports.getMotorRuntimeSummary = async (req, res) => {
  try {
    const { startDate, endDate, groupBy = 'day' } = req.query;
    
    if (!startDate || !endDate) {
      return res.status(400).json({
        success: false,
        message: 'startDate and endDate are required'
      });
    }

    const start = new Date(startDate);
    const end = new Date(endDate);

    // Tổng số record hoạt động
    const totalActiveRecords = await MotorLog.countDocuments({
      timestamp: { $gte: start, $lte: end },
      RunFeedback: true
    });

    // Tổng số record
    const totalRecords = await MotorLog.countDocuments({
      timestamp: { $gte: start, $lte: end }
    });

    // Thống kê theo motor
    const motorStats = await MotorLog.aggregate([
      {
        $match: {
          timestamp: { $gte: start, $lte: end }
        }
      },
      {
        $group: {
          _id: "$name",
          activeRecords: {
            $sum: { $cond: ["$RunFeedback", 1, 0] }
          },
          totalRecords: { $sum: 1 },
          averageSpeed: { $avg: "$Speed" },
          faultCount: {
            $sum: { $cond: ["$Fault", 1, 0] }
          }
        }
      }
    ]);

    const totalDays = Math.max(1, Math.ceil((end - start) / (1000 * 60 * 60 * 24)));
    const summary = {
      period: {
        startDate: start.toISOString().split('T')[0],
        endDate: end.toISOString().split('T')[0],
        totalDays: totalDays,
        groupBy: groupBy
      },
      overall: {
        totalOperatingHours: (totalActiveRecords / 3600).toFixed(2),
        totalOperatingMinutes: (totalActiveRecords / 60).toFixed(0),
        overallEfficiency: (totalRecords > 0 ? ((totalActiveRecords / totalRecords) * 100).toFixed(1) : 0),
        averageDailyRuntime: (totalActiveRecords / totalDays / 3600).toFixed(2)
      },
      motors: motorStats.map(motor => ({
        motorName: motor._id,
        operatingHours: (motor.activeRecords / 3600).toFixed(2),
        efficiency: (motor.totalRecords > 0 ? ((motor.activeRecords / motor.totalRecords) * 100).toFixed(1) : 0),
        averageSpeed: (motor.averageSpeed || 0).toFixed(1),
        faultCount: motor.faultCount
      }))
    };

    res.json({
      success: true,
      data: summary
    });

  } catch (error) {
    console.error('Error in getMotorRuntimeSummary:', error);
    res.status(500).json({
      success: false,
      message: 'Internal server error'
    });
  }
};

// ===== VALVE OPEN TIME REPORTING APIs =====

exports.getValveOpenTimeDaily = async (req, res) => {
  try {
    const { startDate, endDate, valveName, groupBy = 'day' } = req.query;
    if (!startDate || !endDate) {
      return res.status(400).json({ success: false, message: 'startDate and endDate are required' });
    }
    const start = new Date(startDate);
    const end = new Date(endDate);
    const query = { timestamp: { $gte: start, $lte: end }, OpenFeedback: true };
    if (valveName) query.name = valveName;
    let dateFormat, dateField;
    switch (groupBy) {
      case 'week': dateFormat = "%Y-W%U"; dateField = "week"; break;
      case 'month': dateFormat = "%Y-%m"; dateField = "month"; break;
      default: dateFormat = "%Y-%m-%d"; dateField = "date"; break;
    }
    const pipeline = [
      { $match: query },
      { $group: { _id: { [dateField]: { $dateToString: { format: dateFormat, date: "$timestamp" } }, valveName: "$name" }, openSeconds: { $sum: 1 } } },
      { $group: { _id: `$_id.${dateField}`, valves: { $push: { valveName: "$_id.valveName", openSeconds: "$openSeconds" } } } },
      { $sort: { _id: 1 } }
    ];
    const result = await ValveLog.aggregate(pipeline);
    const formattedResult = result.map(period => ({
      [dateField]: period._id,
      valves: Array.isArray(period.valves) ? period.valves.reduce((acc, v) => {
        acc[v.valveName] = {
          openSeconds: v.openSeconds,
          openMinutes: (v.openSeconds * 30 / 60).toFixed(2),
          openHours: (v.openSeconds * 30 / 3600).toFixed(2)
        };
        return acc;
      }, {}) : {}
    }));
    res.json({ success: true, data: { dailyChart: formattedResult } });
  } catch (err) {
    res.status(500).json({ success: false, message: err.message });
  }
};

exports.getValveOpenTimeComparison = async (req, res) => {
  try {
    const { startDate, endDate, groupBy = 'day' } = req.query;
    if (!startDate || !endDate) {
      return res.status(400).json({ success: false, message: 'startDate and endDate are required' });
    }
    const start = new Date(startDate);
    const end = new Date(endDate);
    const totalTimeSpan = (end - start) / 1000;
    const pipeline = [
      { $match: { timestamp: { $gte: start, $lte: end }, OpenFeedback: true } },
      { $group: { _id: "$name", totalOpen: { $sum: 1 } } },
      { $addFields: { openMinutes: { $divide: ["$totalOpen", 2] }, openHours: { $divide: ["$totalOpen", 120] }, openSeconds: { $multiply: ["$totalOpen", 30] }, efficiency: { $multiply: [{ $divide: [ { $multiply: ["$totalOpen", 30] }, totalTimeSpan ] }, 100 ] } } },
      { $sort: { totalOpen: -1 } }
    ];
    const result = await ValveLog.aggregate(pipeline);
    const valveComparison = result.map(valve => ({
      valveName: valve._id,
      openSeconds: valve.openSeconds,
      openHours: valve.openHours,
      efficiency: valve.efficiency?.toFixed(1) || 0
    }));
    res.json({ success: true, data: { valveComparison, summary: { totalValves: result.length, groupBy } } });
  } catch (error) {
    console.error('Error in getValveOpenTimeComparison:', error);
    res.status(500).json({
      success: false,
      message: 'Internal server error'
    });
  }
};

exports.getValveOpenTimeSummary = async (req, res) => {
  try {
    const { startDate, endDate, groupBy = 'day' } = req.query;
    if (!startDate || !endDate) {
      return res.status(400).json({ success: false, message: 'startDate and endDate are required' });
    }
    const start = new Date(startDate);
    const end = new Date(endDate);
    const totalOpenRecords = await ValveLog.countDocuments({ timestamp: { $gte: start, $lte: end }, OpenFeedback: true });
    const totalRecords = await ValveLog.countDocuments({ timestamp: { $gte: start, $lte: end } });
    // Thêm mảng chi tiết từng valve
    const valveStats = await ValveLog.aggregate([
      { $match: { timestamp: { $gte: start, $lte: end } } },
      { $group: {
          _id: "$name",
          openRecords: { $sum: { $cond: ["$OpenFeedback", 1, 0] } },
          totalRecords: { $sum: 1 }
      }}
    ]);
    const valves = valveStats.map(v => ({
      valveName: v._id,
      openHours: (v.openRecords * 30 / 3600).toFixed(2),
      efficiency: v.totalRecords > 0 ? ((v.openRecords / v.totalRecords) * 100).toFixed(1) : 0
    }));
    res.json({ success: true, data: { totalOpenRecords, totalRecords, openHours: (totalOpenRecords * 30 / 3600).toFixed(2), efficiency: ((totalOpenRecords / totalRecords) * 100).toFixed(1), groupBy, valves } });
  } catch (error) {
    console.error('Error in getValveOpenTimeSummary:', error);
    res.status(500).json({
      success: false,
      message: 'Internal server error'
    });
  }
};

// ===== DAMPER OPEN TIME REPORTING APIs =====

exports.getDamperOpenTimeDaily = async (req, res) => {
  try {
    const { startDate, endDate, damperName, groupBy = 'day' } = req.query;
    if (!startDate || !endDate) {
      return res.status(400).json({ success: false, message: 'startDate and endDate are required' });
    }
    const start = new Date(startDate);
    const end = new Date(endDate);
    const query = { timestamp: { $gte: start, $lte: end }, OpenFeedback: true };
    if (damperName) query.name = damperName;
    let dateFormat, dateField;
    switch (groupBy) {
      case 'week': dateFormat = "%Y-W%U"; dateField = "week"; break;
      case 'month': dateFormat = "%Y-%m"; dateField = "month"; break;
      default: dateFormat = "%Y-%m-%d"; dateField = "date"; break;
    }
    const pipeline = [
      { $match: query },
      { $group: { _id: { [dateField]: { $dateToString: { format: dateFormat, date: "$timestamp" } }, damperName: "$name" }, openSeconds: { $sum: 1 } } },
      { $group: { _id: `$_id.${dateField}`, dampers: { $push: { damperName: "$_id.damperName", openSeconds: "$openSeconds" } } } },
      { $sort: { _id: 1 } }
    ];
    const result = await DamperLog.aggregate(pipeline);
    const formattedResult = result.map(period => ({
      [dateField]: period._id,
      dampers: Array.isArray(period.dampers) ? period.dampers.reduce((acc, v) => {
        acc[v.damperName] = {
          openSeconds: v.openSeconds,
          openMinutes: (v.openSeconds * 30 / 60).toFixed(2),
          openHours: (v.openSeconds * 30 / 3600).toFixed(2)
        };
        return acc;
      }, {}) : {}
    }));
    res.json({ success: true, data: { dailyChart: formattedResult } });
  } catch (err) {
    res.status(500).json({ success: false, message: err.message });
  }
};

exports.getDamperOpenTimeComparison = async (req, res) => {
  try {
    const { startDate, endDate, groupBy = 'day' } = req.query;
    if (!startDate || !endDate) {
      return res.status(400).json({ success: false, message: 'startDate and endDate are required' });
    }
    const start = new Date(startDate);
    const end = new Date(endDate);
    const totalTimeSpan = (end - start) / 1000;
    const pipeline = [
      { $match: { timestamp: { $gte: start, $lte: end }, OpenFeedback: true } },
      { $group: { _id: "$name", totalOpen: { $sum: 1 } } },
      { $addFields: { openMinutes: { $divide: ["$totalOpen", 2] }, openHours: { $divide: ["$totalOpen", 120] }, openSeconds: { $multiply: ["$totalOpen", 30] }, efficiency: { $multiply: [{ $divide: [ { $multiply: ["$totalOpen", 30] }, totalTimeSpan ] }, 100 ] } } },
      { $sort: { totalOpen: -1 } }
    ];
    const result = await DamperLog.aggregate(pipeline);
    const damperComparison = result.map(damper => ({
      damperName: damper._id,
      openSeconds: damper.openSeconds,
      openHours: damper.openHours,
      efficiency: damper.efficiency?.toFixed(1) || 0
    }));
    res.json({ success: true, data: { damperComparison, summary: { totalDampers: result.length, groupBy } } });
  } catch (error) {
    console.error('Error in getDamperOpenTimeComparison:', error);
    res.status(500).json({
      success: false,
      message: 'Internal server error'
    });
  }
};

exports.getDamperOpenTimeSummary = async (req, res) => {
  try {
    const { startDate, endDate, groupBy = 'day' } = req.query;
    if (!startDate || !endDate) {
      return res.status(400).json({ success: false, message: 'startDate and endDate are required' });
    }
    const start = new Date(startDate);
    const end = new Date(endDate);
    const totalOpenRecords = await DamperLog.countDocuments({ timestamp: { $gte: start, $lte: end }, OpenFeedback: true });
    const totalRecords = await DamperLog.countDocuments({ timestamp: { $gte: start, $lte: end } });
    // Thêm mảng chi tiết từng damper
    const damperStats = await DamperLog.aggregate([
      { $match: { timestamp: { $gte: start, $lte: end } } },
      { $group: {
          _id: "$name",
          openRecords: { $sum: { $cond: ["$OpenFeedback", 1, 0] } },
          totalRecords: { $sum: 1 }
      }}
    ]);
    const dampers = damperStats.map(d => ({
      damperName: d._id,
      openHours: (d.openRecords * 30 / 3600).toFixed(2),
      efficiency: d.totalRecords > 0 ? ((d.openRecords / d.totalRecords) * 100).toFixed(1) : 0
    }));
    res.json({ success: true, data: { totalOpenRecords, totalRecords, openHours: (totalOpenRecords * 30 / 3600).toFixed(2), efficiency: ((totalOpenRecords / totalRecords) * 100).toFixed(1), groupBy, dampers } });
  } catch (error) {
    console.error('Error in getDamperOpenTimeSummary:', error);
    res.status(500).json({
      success: false,
      message: 'Internal server error'
    });
  }
};

// Helper function to calculate percentage based on groupBy
function calculatePercentage(runtimeSeconds, groupBy) {
  let totalSeconds;
  
  switch (groupBy) {
    case 'week':
      totalSeconds = 7 * 24 * 60 * 60; // 7 days
      break;
    case 'month':
      totalSeconds = 30 * 24 * 60 * 60; // 30 days (approximate)
      break;
    default: // day
      totalSeconds = 24 * 60 * 60; // 24 hours
      break;
  }
  
  // Adjust for 30-second logging interval (multiply by 30)
  const adjustedRuntimeSeconds = runtimeSeconds * 30;
  
  return ((adjustedRuntimeSeconds / totalSeconds) * 100).toFixed(1);
}

// Helper function
function calculateAverageRuntime(formattedResult) {
  if (!formattedResult || formattedResult.length === 0) return 0;
  
  const totalRuntime = formattedResult.reduce((sum, period) => {
    const periodTotal = Object.values(period.motors || {}).reduce((motorSum, motor) => {
      return motorSum + motor.runtime;
    }, 0);
    return sum + periodTotal;
  }, 0);
  
  return (totalRuntime / formattedResult.length / 3600).toFixed(2); // Giờ
}

// API: Tỷ lệ trạng thái hiện tại (chạy/dừng) của motor
exports.getMotorStatusRatio = async (req, res) => {
  try {
    // Lấy bản ghi mới nhất của từng motor
    const latest = await MotorLog.aggregate([
      { $sort: { name: 1, timestamp: -1 } },
      {
        $group: {
          _id: "$name",
          RunFeedback: { $first: "$RunFeedback" },
        }
      }
    ]);
    if (!Array.isArray(latest) || latest.length === 0) {
      return res.json({ success: true, data: { running: 0, stopped: 0, total: 0 } });
    }
    const running = latest.filter(m => m.RunFeedback === true).length;
    const stopped = latest.length - running;
    res.json({ success: true, data: { running, stopped, total: latest.length } });
  } catch (err) {
    res.json({ success: true, data: { running: 0, stopped: 0, total: 0 } });
  }
};

// API: Tỷ lệ tổng thời gian hoạt động giữa các nhóm thiết bị
exports.getTotalRuntimeRatio = async (req, res) => {
  try {
    const { startDate, endDate } = req.query;
    if (!startDate || !endDate) return res.status(400).json({ success: false, message: 'startDate and endDate required' });
    const start = new Date(startDate);
    const end = new Date(endDate);
    let motorRuntime = 0, valveOpen = 0, damperOpen = 0;
    try {
      motorRuntime = await MotorLog.countDocuments({ timestamp: { $gte: start, $lte: end }, RunFeedback: true });
    } catch (e) { motorRuntime = 0; }
    try {
      valveOpen = await ValveLog.countDocuments({ timestamp: { $gte: start, $lte: end }, OpenFeedback: true });
    } catch (e) { valveOpen = 0; }
    try {
      damperOpen = await DamperLog.countDocuments({ timestamp: { $gte: start, $lte: end }, OpenFeedback: true });
    } catch (e) { damperOpen = 0; }
    res.json({ success: true, data: { motorRuntime, valveOpen, damperOpen } });
  } catch (err) {
    res.json({ success: true, data: { motorRuntime: 0, valveOpen: 0, damperOpen: 0 } });
  }
}; 

exports.exportPdfReport = async (req, res) => {
    try {
        const { startDate, endDate, summary, charts } = req.body;

        // 1. Render EJS template to HTML string
        const templatePath = path.join(__dirname, '..', 'views', 'reporting-pdf.ejs');
        const template = fs.readFileSync(templatePath, 'utf-8');
        const html = ejs.render(template, {
            startDate,
            endDate,
            summary,
            charts
        });

        // 2. Launch Puppeteer and create PDF
        const browser = await puppeteer.launch({ 
            headless: true,
            args: ['--no-sandbox', '--disable-setuid-sandbox'] // Important for running in some environments
        });
        const page = await browser.newPage();
        
        // Set content and wait for images to load
        await page.setContent(html, { waitUntil: 'networkidle0' });

        const pdfBuffer = await page.pdf({
            format: 'A4',
            printBackground: true,
            margin: {
                top: '20px',
                right: '20px',
                bottom: '40px', // Make space for footer
                left: '20px'
            },
            displayHeaderFooter: true,
            footerTemplate: `
                <div style="font-size:10px; width:100%; text-align:center; padding: 0 20px;">
                    <span class="pageNumber"></span> / <span class="totalPages"></span>
                </div>
            `
        });

        await browser.close();

        // 3. Send PDF back to client
        res.contentType('application/pdf');
        res.send(pdfBuffer);

    } catch (error) {
        console.error('Error exporting PDF:', error);
        res.status(500).json({ success: false, message: 'Failed to export PDF report.' });
    }
}; 