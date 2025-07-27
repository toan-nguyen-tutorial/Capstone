const mongoose = require('mongoose');

const ahuLogSchema = new mongoose.Schema({
  timestamp: { type: Date, default: Date.now, index: true },
  name: { type: String, required: true },
  data: { type: Object, required: true }
});

module.exports = mongoose.model('AHULog', ahuLogSchema); 