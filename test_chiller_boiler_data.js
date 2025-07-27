const mongoose = require('mongoose');
const ChillerLog = require('./models/ChillerLog');
const BoilerLog = require('./models/BoilerLog');

// Kết nối MongoDB
mongoose.connect('mongodb://localhost:27017/hvac_dashboard')
  .then(() => console.log('Connected to MongoDB'))
  .catch(err => console.error('MongoDB connection error:', err));

async function testData() {
  try {
    console.log('=== Testing Chiller Data ===');
    const chillerCount = await ChillerLog.countDocuments();
    console.log(`Chiller records count: ${chillerCount}`);
    
    if (chillerCount > 0) {
      const latestChiller = await ChillerLog.findOne().sort({ timestamp: -1 });
      console.log('Latest Chiller data:', JSON.stringify(latestChiller, null, 2));
    }

    console.log('\n=== Testing Boiler Data ===');
    const boilerCount = await BoilerLog.countDocuments();
    console.log(`Boiler records count: ${boilerCount}`);
    
    if (boilerCount > 0) {
      const latestBoiler = await BoilerLog.findOne().sort({ timestamp: -1 });
      console.log('Latest Boiler data:', JSON.stringify(latestBoiler, null, 2));
    }

    // Test API endpoints
    console.log('\n=== Testing API Endpoints ===');
    
    // Test chiller API
    const chillerData = await ChillerLog.find({ 
      timestamp: { $gte: new Date(Date.now() - 5 * 60 * 1000) } 
    }, {
      timestamp: 1,
      data: 1,
      _id: 0
    }).sort({ timestamp: 1 }).limit(5);
    
    console.log('Chiller API test data:', chillerData.length, 'records');
    if (chillerData.length > 0) {
      console.log('Sample chiller record:', JSON.stringify(chillerData[0], null, 2));
    }

    // Test boiler API
    const boilerData = await BoilerLog.find({ 
      timestamp: { $gte: new Date(Date.now() - 5 * 60 * 1000) } 
    }, {
      timestamp: 1,
      data: 1,
      _id: 0
    }).sort({ timestamp: 1 }).limit(5);
    
    console.log('Boiler API test data:', boilerData.length, 'records');
    if (boilerData.length > 0) {
      console.log('Sample boiler record:', JSON.stringify(boilerData[0], null, 2));
    }

  } catch (error) {
    console.error('Error testing data:', error);
  } finally {
    mongoose.connection.close();
  }
}

testData(); 