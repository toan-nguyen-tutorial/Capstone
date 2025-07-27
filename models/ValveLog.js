const mongoose = require('mongoose');

const valveLogSchema = new mongoose.Schema({
  timestamp: { type: Date, default: Date.now, index: true },
  OpenFeedback: { type: Boolean, required: true },
  ValvePosition: { type: Number, required: true },
  Fault: { type: Boolean, required: true },
  name: { type: String, required: true }
});

module.exports = mongoose.model('ValveLog', valveLogSchema); 