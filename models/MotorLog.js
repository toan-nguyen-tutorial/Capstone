const mongoose = require('mongoose');

const motorLogSchema = new mongoose.Schema({
  timestamp: { type: Date, default: Date.now, index: true },
  Speed: { type: Number, required: true },
  RunFeedback: { type: Boolean, required: true },
  Runtime: { type: String, required: true },
  Fault: { type: Boolean, required: true },
  name: { type: String, required: true }
});

module.exports = mongoose.model('MotorLog', motorLogSchema); 