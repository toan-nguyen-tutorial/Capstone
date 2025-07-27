const { Router } = require('express');
const reportingController = require('../controllers/reportingController');
const router = Router();
const { requireAuth } = require('../middleware/authMiddleware');

// Render reporting page
router.get('/', reportingController.getReporting);

// ===== MOTOR RUNTIME REPORTING APIs =====

/**
 * API 1: Thời gian hoạt động theo ngày
 * GET /api/reporting/motor-runtime/daily
 * Query: startDate, endDate, motorName (optional)
 * 
 * Response:
 * {
 *   success: true,
 *   data: {
 *     dailyChart: [
 *       {
 *         date: "2024-01-01",
 *         motors: {
 *           "Motor1": { runtime: 28800, runtimeFormatted: "08:00:00", percentage: 33.3 },
 *           "Motor2": { runtime: 43200, runtimeFormatted: "12:00:00", percentage: 50.0 }
 *         }
 *       }
 *     ],
 *     summary: { totalDays: 7, averageRuntime: "10.5" }
 *   }
 * }
 */
router.get('/api/motor-runtime/daily', reportingController.getMotorRuntimeDaily);

/**
 * API 2: So sánh thời gian hoạt động giữa các motor
 * GET /api/reporting/motor-runtime/comparison
 * Query: startDate, endDate
 * 
 * Response:
 * {
 *   success: true,
 *   data: {
 *     motorComparison: [
 *       {
 *         motorName: "Motor1",
 *         totalRuntime: 28800,
 *         runtimeFormatted: "08:00:00",
 *         efficiency: 33.3,
 *         averageDailyRuntime: "8.0"
 *       }
 *     ],
 *     summary: {
 *       totalMotors: 3,
 *       averageEfficiency: 45.2,
 *       mostActiveMotor: "Motor2",
 *       leastActiveMotor: "Motor3"
 *     }
 *   }
 * }
 */
router.get('/api/motor-runtime/comparison', reportingController.getMotorRuntimeComparison);

/**
 * API 3: Thống kê tổng hợp
 * GET /api/reporting/motor-runtime/summary
 * Query: startDate, endDate
 * 
 * Response:
 * {
 *   success: true,
 *   data: {
 *     period: { startDate: "2024-01-01", endDate: "2024-01-07", totalDays: 7 },
 *     overall: {
 *       totalOperatingHours: "168.5",
 *       totalOperatingMinutes: "10110",
 *       overallEfficiency: "45.2",
 *       averageDailyRuntime: "24.1"
 *     },
 *     motors: [
 *       {
 *         motorName: "Motor1",
 *         operatingHours: "56.2",
 *         efficiency: "33.3",
 *         averageSpeed: "75.5",
 *         faultCount: 2
 *       }
 *     ]
 *   }
 * }
 */
router.get('/api/motor-runtime/summary', reportingController.getMotorRuntimeSummary);

// ===== VALVE OPEN TIME REPORTING APIs =====
router.get('/api/valve-open-time/daily', reportingController.getValveOpenTimeDaily);
router.get('/api/valve-open-time/comparison', reportingController.getValveOpenTimeComparison);
router.get('/api/valve-open-time/summary', reportingController.getValveOpenTimeSummary);

// ===== DAMPER OPEN TIME REPORTING APIs =====
router.get('/api/damper-open-time/daily', reportingController.getDamperOpenTimeDaily);
router.get('/api/damper-open-time/comparison', reportingController.getDamperOpenTimeComparison);
router.get('/api/damper-open-time/summary', reportingController.getDamperOpenTimeSummary);

// Pie chart: Tỷ lệ trạng thái hiện tại (chạy/dừng) của motor
router.get('/api/motor-status-ratio', requireAuth, reportingController.getMotorStatusRatio);
// Pie chart: Tỷ lệ tổng thời gian hoạt động giữa các nhóm thiết bị
router.get('/api/total-runtime-ratio', requireAuth, reportingController.getTotalRuntimeRatio);
// PDF Export
router.post('/api/export-pdf', requireAuth, reportingController.exportPdfReport);

module.exports = router; 