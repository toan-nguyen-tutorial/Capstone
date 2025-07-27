const mongoose = require('mongoose');

const boilerLogSchema = new mongoose.Schema({
  timestamp: { type: Date, default: Date.now, index: true },
  name: { type: String, required: true },
  data: { type: Object, required: true }
});

module.exports = mongoose.model('BoilerLog', boilerLogSchema); 