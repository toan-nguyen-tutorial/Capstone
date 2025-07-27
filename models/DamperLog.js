const mongoose = require('mongoose');

const damperLogSchema = new mongoose.Schema({
  timestamp: { type: Date, default: Date.now, index: true },
  OpenFeedback: { type: Boolean, required: true },
  DamperPosition: { type: Number, required: true },
  Fault: { type: Boolean, required: true },
  name: { type: String, required: true }
});

module.exports = mongoose.model('DamperLog', damperLogSchema); 