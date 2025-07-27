const MotorLog = require('../models/MotorLog');
const ValveLog = require('../models/ValveLog');
const DamperLog = require('../models/DamperLog');
const ChillerLog = require('../models/ChillerLog');
const BoilerLog = require('../models/BoilerLog');

// Render chart page
exports.getChart = (req, res) => {
  res.render('chart', { user: res.locals.user });
};

// Render valve chart page
exports.getValveChart = (req, res) => {
  res.render('valve-chart', { user: res.locals.user });
};

// Render damper chart page
exports.getDamperChart = (req, res) => {
  res.render('damper-chart', { user: res.locals.user });
};

// API endpoint lấy dữ liệu speed của motor (lịch sử)
exports.getMotorSpeedData = async (req, res) => {
  try {
    const duration = req.params.duration || req.query.duration || 30; // Thời gian tính bằng phút
    const { motors } = req.query;
    // Tính thời gian bắt đầu (từ hiện tại trừ đi duration phút)
    const startTime = new Date(Date.now() - duration * 60 * 1000);
    // Tạo query filter
    let query = {
      timestamp: { $gte: startTime }
    };
    // Nếu có parameter motors, chỉ lấy dữ liệu của motor được chọn
    if (motors) {
      const motorList = motors.split(',').map(m => m.trim());
      query.name = { $in: motorList };
    }
    // Chỉ lấy timestamp, name và Speed để tối ưu hóa
    const motorData = await MotorLog.find(query, {
      timestamp: 1,
      name: 1,
      Speed: 1,
      _id: 0
    }).sort({ timestamp: 1 });
    // Format data for frontend
    const formattedData = motorData.map(log => ({
      motorName: log.name,
      speed: log.Speed,
      timestamp: log.timestamp
    }));
    res.json(formattedData);
  } catch (error) {
    console.error('Error fetching motor speed data:', error);
    res.status(500).json({
      success: false,
      error: 'Failed to fetch motor speed data'
    });
  }
};

// API endpoint lấy dữ liệu vị trí valve (lịch sử)
exports.getValvePositionData = async (req, res) => {
  try {
    const duration = req.params.duration || req.query.duration || 30;
    const { valves } = req.query;
    const startTime = new Date(Date.now() - duration * 60 * 1000);
    let query = { timestamp: { $gte: startTime } };
    if (valves) {
      const valveList = valves.split(',').map(v => v.trim());
      query.name = { $in: valveList };
    }
    const valveData = await ValveLog.find(query, {
      timestamp: 1,
      name: 1,
      ValvePosition: 1,
      _id: 0
    }).sort({ timestamp: 1 });
    const formattedData = valveData.map(log => ({
      valveName: log.name,
      valvePosition: log.ValvePosition,
      timestamp: log.timestamp
    }));
    res.json(formattedData);
  } catch (error) {
    console.error('Error fetching valve position data:', error);
    res.status(500).json({ success: false, error: 'Failed to fetch valve position data' });
  }
};
// API endpoint lấy dữ liệu vị trí damper (lịch sử)
exports.getDamperPositionData = async (req, res) => {
  try {
    const duration = req.params.duration || req.query.duration || 30;
    const { dampers } = req.query;
    const startTime = new Date(Date.now() - duration * 60 * 1000);
    let query = { timestamp: { $gte: startTime } };
    if (dampers) {
      const damperList = dampers.split(',').map(d => d.trim());
      query.name = { $in: damperList };
    }
    const damperData = await DamperLog.find(query, {
      timestamp: 1,
      name: 1,
      DamperPosition: 1,
      _id: 0
    }).sort({ timestamp: 1 });
    const formattedData = damperData.map(log => ({
      damperName: log.name,
      damperPosition: log.DamperPosition,
      timestamp: log.timestamp
    }));
    res.json(formattedData);
  } catch (error) {
    console.error('Error fetching damper position data:', error);
    res.status(500).json({ success: false, error: 'Failed to fetch damper position data' });
  }
};

// API endpoint lấy dữ liệu nhiệt độ chiller (lịch sử)
exports.getChillerTempData = async (req, res) => {
  try {
    const duration = req.params.duration || req.query.duration || 30;
    const startTime = new Date(Date.now() - duration * 60 * 1000);
    const chillerData = await ChillerLog.find({ timestamp: { $gte: startTime } }, {
      timestamp: 1,
      data: 1,
      _id: 0
    }).sort({ timestamp: 1 });
    
    const formattedData = chillerData.map(log => ({
      timestamp: log.timestamp,
      chillerTempOut: log.data.ChillerTempOut || 0,
      coolingTowerTempOut: log.data.CoolingTowerTempOut || 0
    }));
    res.json(formattedData);
  } catch (error) {
    console.error('Error fetching chiller temperature data:', error);
    res.status(500).json({ success: false, error: 'Failed to fetch chiller temperature data' });
  }
};

// API endpoint lấy dữ liệu nhiệt độ boiler (lịch sử)
exports.getBoilerTempData = async (req, res) => {
  try {
    const duration = req.params.duration || req.query.duration || 30;
    const startTime = new Date(Date.now() - duration * 60 * 1000);
    const boilerData = await BoilerLog.find({ timestamp: { $gte: startTime } }, {
      timestamp: 1,
      data: 1,
      _id: 0
    }).sort({ timestamp: 1 });
    
    const formattedData = boilerData.map(log => ({
      timestamp: log.timestamp,
      boilerTempOut: log.data.BoilerTemperatureOutput || 0,
      heatExchangerTempOut: log.data.HeatExchangerTemperatureOutput || 0
    }));
    res.json(formattedData);
  } catch (error) {
    console.error('Error fetching boiler temperature data:', error);
    res.status(500).json({ success: false, error: 'Failed to fetch boiler temperature data' });
  }
}; 