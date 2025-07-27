const mongoose = require('mongoose');
const ChillerLog = require('./models/ChillerLog');
const BoilerLog = require('./models/BoilerLog');

// Kết nối MongoDB
mongoose.connect('mongodb://localhost:27017/hvac_dashboard')
  .then(async () => {
    console.log('Connected to MongoDB');
    
    try {
      // Xóa dữ liệu cũ nếu có
      await ChillerLog.deleteMany({});
      await BoilerLog.deleteMany({});
      console.log('Cleared existing data');
      
      // Tạo dữ liệu mẫu cho chiller (5 phút gần đây)
      const chillerData = [];
      const now = new Date();
      for (let i = 0; i < 300; i++) { // 5 phút = 300 giây
        const timestamp = new Date(now.getTime() - (300 - i) * 1000);
        chillerData.push({
          timestamp: timestamp,
          name: 'CHILLER',
          data: {
            ChillerTempOut: Math.floor(Math.random() * 20) + 15, // 15-35°C
            CoolingTowerTempOut: Math.floor(Math.random() * 15) + 20, // 20-35°C
            ChillerStatus: Math.random() > 0.5 ? 'Running' : 'Stopped',
            CoolingTowerStatus: Math.random() > 0.5 ? 'Running' : 'Stopped'
          }
        });
      }
      
      // Tạo dữ liệu mẫu cho boiler (5 phút gần đây)
      const boilerData = [];
      for (let i = 0; i < 300; i++) { // 5 phút = 300 giây
        const timestamp = new Date(now.getTime() - (300 - i) * 1000);
        boilerData.push({
          timestamp: timestamp,
          name: 'BOILER',
          data: {
            BoilerTemperatureOutput: Math.floor(Math.random() * 40) + 60, // 60-100°C
            HeatExchangerTemperatureOutput: Math.floor(Math.random() * 30) + 50, // 50-80°C
            BoilerStatus: Math.random() > 0.5 ? 'Running' : 'Stopped',
            HeatExchangerStatus: Math.random() > 0.5 ? 'Running' : 'Stopped'
          }
        });
      }
      
      // Lưu dữ liệu vào database
      await ChillerLog.insertMany(chillerData);
      await BoilerLog.insertMany(boilerData);
      
      console.log(`Added ${chillerData.length} chiller records`);
      console.log(`Added ${boilerData.length} boiler records`);
      
      // Kiểm tra dữ liệu đã được lưu
      const chillerCount = await ChillerLog.countDocuments();
      const boilerCount = await BoilerLog.countDocuments();
      console.log(`Total ChillerLog records: ${chillerCount}`);
      console.log(`Total BoilerLog records: ${boilerCount}`);
      
      // Hiển thị mẫu dữ liệu
      const sampleChiller = await ChillerLog.findOne();
      const sampleBoiler = await BoilerLog.findOne();
      console.log('\nSample ChillerLog:', JSON.stringify(sampleChiller, null, 2));
      console.log('\nSample BoilerLog:', JSON.stringify(sampleBoiler, null, 2));
      
    } catch (error) {
      console.error('Error adding sample data:', error);
    } finally {
      mongoose.connection.close();
      console.log('Database connection closed');
    }
  })
  .catch(err => {
    console.error('MongoDB connection error:', err);
    console.log('\nPlease make sure MongoDB is running:');
    console.log('1. Install MongoDB if not installed');
    console.log('2. Start MongoDB service: mongod');
    console.log('3. Or use MongoDB Atlas cloud database');
  }); 