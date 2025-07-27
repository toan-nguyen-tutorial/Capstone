const { Router } = require('express');
const chartController = require('../controllers/chartController');
const router = Router();

router.get('/', chartController.getChart);
router.get('/valve', chartController.getValveChart);
router.get('/damper', chartController.getDamperChart);
router.get('/api/motor-speed/:duration', chartController.getMotorSpeedData);
router.get('/api/valve-position/:duration', chartController.getValvePositionData);
router.get('/api/damper-position/:duration', chartController.getDamperPositionData);
router.get('/api/chiller-temp/:duration', chartController.getChillerTempData);
router.get('/api/boiler-temp/:duration', chartController.getBoilerTempData);

module.exports = router; 