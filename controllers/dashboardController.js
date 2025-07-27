const mqtt = require('mqtt');
const MQTT_BROKER_URL = process.env.MQTT_BROKER_URL;
const mqttOptions = {
  username: process.env.MQTT_USERNAME,
  password: process.env.MQTT_PASSWORD,
  rejectUnauthorized: false,
};
let client;
if (!global._mqttClient) {
  client = mqtt.connect(MQTT_BROKER_URL, mqttOptions);
  global._mqttClient = client;
} else {
  client = global._mqttClient;
}

exports.getDashboard = (req, res) => {
  res.render('dashboard', { user: res.locals.user });
}; 