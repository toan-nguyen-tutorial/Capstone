const { Router } = require('express');
const dataLookupController = require('../controllers/dataLookupController');
const router = Router();

router.get('/', dataLookupController.getDataLookup);
router.post('/api', dataLookupController.postDataLookup);
router.post('/api/export', dataLookupController.exportDataLookup);
router.get('/api/device-names', dataLookupController.getDeviceNames);

module.exports = router; 