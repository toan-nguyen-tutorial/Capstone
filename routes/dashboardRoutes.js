const { Router } = require("express");
const dashboardController = require('../controllers/dashboardController');
const router = Router();
const { requireAuth } = require('../middleware/authMiddleware');

router.get("/", dashboardController.getDashboard);

module.exports = router; 