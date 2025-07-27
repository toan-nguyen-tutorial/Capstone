// data_cleanup.js - Script để cleanup dữ liệu cũ và giải phóng không gian database
const mongoose = require('mongoose');
require('dotenv').config();

// Import models
const MotorLog = require('./models/MotorLog');
const ValveLog = require('./models/ValveLog');
const DamperLog = require('./models/DamperLog');
const AHULog = require('./models/AHULog');
const ChillerLog = require('./models/ChillerLog');
const BoilerLog = require('./models/BoilerLog');

// Data retention policy
const RETENTION_DAYS = 30; // Giữ dữ liệu 30 ngày
const CLEANUP_BATCH_SIZE = 1000; // Xóa từng batch 1000 records

async function cleanupOldData() {
  try {
    console.log('🔄 Starting data cleanup...');
    
    // Calculate cutoff date
    const cutoffDate = new Date();
    cutoffDate.setDate(cutoffDate.getDate() - RETENTION_DAYS);
    
    console.log(`📅 Deleting data older than: ${cutoffDate.toISOString()}`);
    
    // Cleanup MotorLog
    console.log('🧹 Cleaning MotorLog...');
    const motorResult = await MotorLog.deleteMany({
      timestamp: { $lt: cutoffDate }
    });
    console.log(`✅ Deleted ${motorResult.deletedCount} MotorLog records`);
    
    // Cleanup ValveLog
    console.log('🧹 Cleaning ValveLog...');
    const valveResult = await ValveLog.deleteMany({
      timestamp: { $lt: cutoffDate }
    });
    console.log(`✅ Deleted ${valveResult.deletedCount} ValveLog records`);
    
    // Cleanup DamperLog
    console.log('🧹 Cleaning DamperLog...');
    const damperResult = await DamperLog.deleteMany({
      timestamp: { $lt: cutoffDate }
    });
    console.log(`✅ Deleted ${damperResult.deletedCount} DamperLog records`);
    
    // Cleanup AHULog
    console.log('🧹 Cleaning AHULog...');
    const ahuResult = await AHULog.deleteMany({
      timestamp: { $lt: cutoffDate }
    });
    console.log(`✅ Deleted ${ahuResult.deletedCount} AHULog records`);
    
    // Cleanup ChillerLog
    console.log('🧹 Cleaning ChillerLog...');
    const chillerResult = await ChillerLog.deleteMany({
      timestamp: { $lt: cutoffDate }
    });
    console.log(`✅ Deleted ${chillerResult.deletedCount} ChillerLog records`);
    
    // Cleanup BoilerLog
    console.log('🧹 Cleaning BoilerLog...');
    const boilerResult = await BoilerLog.deleteMany({
      timestamp: { $lt: cutoffDate }
    });
    console.log(`✅ Deleted ${boilerResult.deletedCount} BoilerLog records`);
    
    const totalDeleted = motorResult.deletedCount + valveResult.deletedCount + 
                        damperResult.deletedCount + ahuResult.deletedCount + 
                        chillerResult.deletedCount + boilerResult.deletedCount;
    
    console.log(`🎉 Cleanup completed! Total records deleted: ${totalDeleted}`);
    
    // Show database stats
    await showDatabaseStats();
    
  } catch (error) {
    console.error('❌ Error during cleanup:', error);
  }
}

async function showDatabaseStats() {
  try {
    console.log('\n📊 Database Statistics:');
    
    const motorCount = await MotorLog.countDocuments();
    const valveCount = await ValveLog.countDocuments();
    const damperCount = await DamperLog.countDocuments();
    const ahuCount = await AHULog.countDocuments();
    const chillerCount = await ChillerLog.countDocuments();
    const boilerCount = await BoilerLog.countDocuments();
    
    console.log(`MotorLog: ${motorCount} records`);
    console.log(`ValveLog: ${valveCount} records`);
    console.log(`DamperLog: ${damperCount} records`);
    console.log(`AHULog: ${ahuCount} records`);
    console.log(`ChillerLog: ${chillerCount} records`);
    console.log(`BoilerLog: ${boilerCount} records`);
    
    const totalRecords = motorCount + valveCount + damperCount + ahuCount + chillerCount + boilerCount;
    console.log(`Total: ${totalRecords} records`);
    
    // Estimate database size (rough calculation)
    const avgRecordSize = 200; // bytes per record
    const estimatedSizeMB = (totalRecords * avgRecordSize) / (1024 * 1024);
    console.log(`Estimated database size: ${estimatedSizeMB.toFixed(2)} MB`);
    
  } catch (error) {
    console.error('❌ Error getting database stats:', error);
  }
}

async function createIndexes() {
  try {
    console.log('🔧 Creating database indexes for better performance...');
    
    // Create indexes for better query performance
    await MotorLog.collection.createIndex({ timestamp: 1, name: 1, RunFeedback: 1 });
    await ValveLog.collection.createIndex({ timestamp: 1, name: 1 });
    await DamperLog.collection.createIndex({ timestamp: 1, name: 1 });
    await AHULog.collection.createIndex({ timestamp: 1 });
    await ChillerLog.collection.createIndex({ timestamp: 1 });
    await BoilerLog.collection.createIndex({ timestamp: 1 });
    
    console.log('✅ Indexes created successfully');
    
  } catch (error) {
    console.error('❌ Error creating indexes:', error);
  }
}

// Main function
async function main() {
  try {
    // Connect to MongoDB
    const dbURI = process.env.MONGODB_URI;
    await mongoose.connect(dbURI);
    console.log('🔗 Connected to MongoDB');
    
    // Create indexes first
    await createIndexes();
    
    // Run cleanup
    await cleanupOldData();
    
    console.log('✨ All operations completed successfully!');
    
  } catch (error) {
    console.error('❌ Fatal error:', error);
  } finally {
    // Close connection
    await mongoose.connection.close();
    console.log('🔌 Disconnected from MongoDB');
    process.exit(0);
  }
}

// Run if called directly
if (require.main === module) {
  main();
}

module.exports = { cleanupOldData, showDatabaseStats, createIndexes }; 