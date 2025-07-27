const axios = require('axios');

// Test API endpoints
async function testEndpoints() {
  try {
    console.log('Testing API endpoints...');
    
    // Test chiller temperature endpoint
    console.log('\n1. Testing chiller temperature endpoint...');
    try {
      const chillerResponse = await axios.get('http://localhost:3000/chart/api/chiller-temp/5');
      console.log('Chiller API Response:', chillerResponse.data);
    } catch (error) {
      console.log('Chiller API Error:', error.response?.status, error.response?.statusText);
      if (error.response?.status === 401) {
        console.log('Authentication required - need to login first');
      }
    }
    
    // Test boiler temperature endpoint
    console.log('\n2. Testing boiler temperature endpoint...');
    try {
      const boilerResponse = await axios.get('http://localhost:3000/chart/api/boiler-temp/5');
      console.log('Boiler API Response:', boilerResponse.data);
    } catch (error) {
      console.log('Boiler API Error:', error.response?.status, error.response?.statusText);
      if (error.response?.status === 401) {
        console.log('Authentication required - need to login first');
      }
    }
    
    // Test motor speed endpoint
    console.log('\n3. Testing motor speed endpoint...');
    try {
      const motorResponse = await axios.get('http://localhost:3000/chart/api/motor-speed/5');
      console.log('Motor API Response:', motorResponse.data);
    } catch (error) {
      console.log('Motor API Error:', error.response?.status, error.response?.statusText);
      if (error.response?.status === 401) {
        console.log('Authentication required - need to login first');
      }
    }
    
  } catch (error) {
    console.error('Error testing endpoints:', error.message);
  }
}

testEndpoints(); 