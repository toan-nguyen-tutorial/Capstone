const MotorLog = require('../models/MotorLog');
const ValveLog = require('../models/ValveLog');
const DamperLog = require('../models/DamperLog');
const BoilerLog = require('../models/BoilerLog');
const ChillerLog = require('../models/ChillerLog');
const AHULog = require('../models/AHULog');
const { Parser } = require('json2csv');

exports.getDataLookup = (req, res) => {
  res.render('data-lookup', { user: res.locals.user });
};

exports.postDataLookup = async (req, res) => {
  try {
    const { deviceType, deviceName, dateFrom, dateTo } = req.body;
    let Model;
    let query = {};
    switch (deviceType) {
      case 'Motor': Model = MotorLog; break;
      case 'Valve': Model = ValveLog; break;
      case 'Damper': Model = DamperLog; break;
      case 'Boiler': Model = BoilerLog; break;
      case 'Chiller': Model = ChillerLog; break;
      case 'AHU': Model = AHULog; break;
      default: Model = null;
    }
    if (dateFrom || dateTo) {
      query.timestamp = {};
      if (dateFrom) query.timestamp.$gte = new Date(dateFrom);
      if (dateTo) query.timestamp.$lte = new Date(dateTo);
    }
    if (deviceName && Model && ['Motor','Valve','Damper'].includes(deviceType)) {
      query.name = deviceName;
    }
    let data = [];
    if (Model) {
      data = await Model.find(query).sort({ timestamp: -1 }).lean();
    } else {
      const [motors, valves, dampers, boilers, chillers, ahus] = await Promise.all([
        MotorLog.find(query).lean(),
        ValveLog.find(query).lean(),
        DamperLog.find(query).lean(),
        BoilerLog.find(query).lean(),
        ChillerLog.find(query).lean(),
        AHULog.find(query).lean()
      ]);
      data = [
        ...motors.map(d=>({...d, deviceType:'Motor'})),
        ...valves.map(d=>({...d, deviceType:'Valve'})),
        ...dampers.map(d=>({...d, deviceType:'Damper'})),
        ...boilers.map(d=>({...d, deviceType:'Boiler'})),
        ...chillers.map(d=>({...d, deviceType:'Chiller'})),
        ...ahus.map(d=>({...d, deviceType:'AHU'})),
      ];
      data.sort((a,b)=>b.timestamp-a.timestamp);
    }
    res.json({ success: true, data });
  } catch (err) {
    res.status(500).json({ success: false, error: err.message });
  }
};

exports.exportDataLookup = async (req, res) => {
  try {
    const { deviceType, deviceName, dateFrom, dateTo } = req.body;
    let Model;
    let query = {};
    switch (deviceType) {
      case 'Motor': Model = MotorLog; break;
      case 'Valve': Model = ValveLog; break;
      case 'Damper': Model = DamperLog; break;
      case 'Boiler': Model = BoilerLog; break;
      case 'Chiller': Model = ChillerLog; break;
      case 'AHU': Model = AHULog; break;
      default: Model = null;
    }
    if (dateFrom || dateTo) {
      query.timestamp = {};
      if (dateFrom) query.timestamp.$gte = new Date(dateFrom);
      if (dateTo) query.timestamp.$lte = new Date(dateTo);
    }
    if (deviceName && Model && ['Motor','Valve','Damper'].includes(deviceType)) {
      query.name = deviceName;
    }
    
    let data = [];
    if (Model) {
      data = await Model.find(query).sort({ timestamp: -1 }).lean();
    } else {
       const [motors, valves, dampers, boilers, chillers, ahus] = await Promise.all([
        MotorLog.find(query).lean(),
        ValveLog.find(query).lean(),
        DamperLog.find(query).lean(),
        BoilerLog.find(query).lean(),
        ChillerLog.find(query).lean(),
        AHULog.find(query).lean()
      ]);
      data = [
        ...motors.map(d=>({...d, deviceType:'Motor'})),
        ...valves.map(d=>({...d, deviceType:'Valve'})),
        ...dampers.map(d=>({...d, deviceType:'Damper'})),
        ...boilers.map(d=>({...d, deviceType:'Boiler'})),
        ...chillers.map(d=>({...d, deviceType:'Chiller'})),
        ...ahus.map(d=>({...d, deviceType:'AHU'})),
      ];
      data.sort((a,b)=>b.timestamp-a.timestamp);
    }

    if (data.length === 0) {
      return res.status(404).json({ success: false, message: 'No data to export.' });
    }

    // Define fields for CSV based on deviceType
    let fields;
    if (deviceType === 'Motor') {
      fields = ['timestamp', 'name', 'Speed', 'RunFeedback', 'Runtime', 'Fault'];
    } else if (deviceType === 'Valve') {
      fields = ['timestamp', 'name', 'OpenFeedback', 'ValvePosition', 'Fault'];
    } else if (deviceType === 'Damper') {
      fields = ['timestamp', 'name', 'OpenFeedback', 'DamperPosition', 'Fault'];
    } else if (deviceType === 'Boiler' || deviceType === 'Chiller' || deviceType === 'AHU') {
       fields = ['timestamp', 'name', 'data'];
    } else { // All devices
      fields = ['timestamp', 'deviceType', 'name', 'Speed', 'RunFeedback', 'Runtime', 'OpenFeedback', 'ValvePosition', 'DamperPosition', 'Fault', 'data'];
    }
    
    const json2csvParser = new Parser({ fields });
    const csv = json2csvParser.parse(data);

    res.header('Content-Type', 'text/csv');
    res.attachment(`export-${deviceType}-${Date.now()}.csv`);
    res.send(csv);

  } catch (err) {
    res.status(500).json({ success: false, error: err.message });
  }
};


exports.getDeviceNames = async (req, res) => {
  try {
    const { type } = req.query;
    let Model;
    switch (type) {
      case 'Motor': Model = MotorLog; break;
      case 'Valve': Model = ValveLog; break;
      case 'Damper': Model = DamperLog; break;
      case 'Boiler': Model = BoilerLog; break;
      case 'Chiller': Model = ChillerLog; break;
      case 'AHU': Model = AHULog; break;
      default: return res.json({ success: false, names: [] });
    }
    const names = await Model.distinct('name');
    res.json({ success: true, names });
  } catch (err) {
    res.status(500).json({ success: false, error: err.message });
  }
}; 