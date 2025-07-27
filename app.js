// app.js - Main server file for HVAC Dashboard
// Provides Express server, MQTT integration, Socket.IO real-time, MongoDB logging

const express = require("express");
const mongoose = require("mongoose");
const authRouters = require("./routes/authRoutes");
const dashboardRoutes = require("./routes/dashboardRoutes");
const chartRoutes = require("./routes/chartRoutes");
const dataLookupRoutes = require("./routes/dataLookupRoutes");
const reportingRoutes = require("./routes/reportingRoutes");
const cookieParser = require("cookie-parser");
const { requireAuth, checkUser } = require("./middleware/authMiddleware");
const http = require("http");
const mqtt = require("mqtt");
const { Server } = require("socket.io");
const MotorLog = require("./models/MotorLog");
const ValveLog = require("./models/ValveLog");
const DamperLog = require("./models/DamperLog");
const AHULog = require("./models/AHULog");
const ChillerLog = require("./models/ChillerLog");
const BoilerLog = require("./models/BoilerLog");


require("dotenv").config();

const app = express();
const server = http.createServer(app);
const io = new Server(server);
const PORT = process.env.PORT || 3000;

// --- Middleware setup ---
app.use(express.static("public"));
// Tăng giới hạn payload cho JSON và form
app.use(express.json({ limit: '20mb' }));
app.use(express.urlencoded({ limit: '20mb', extended: true }));
app.use(cookieParser());
app.use(checkUser); // Attach user info to req if logged in
app.set("view engine", "ejs");

// --- MQTT Configuration ---
const MQTT_BROKER_URL = process.env.MQTT_BROKER_URL;
const MQTT_TOPIC = process.env.MQTT_TOPIC;
const mqttOptions = {
  username: process.env.MQTT_USERNAME,
  password: process.env.MQTT_PASSWORD,
  rejectUnauthorized: false,
};

let latestData = {};
const client = mqtt.connect(MQTT_BROKER_URL, mqttOptions);

// Connect and subscribe to main data topic
client.on("connect", () => {
  console.log("Connected to MQTT Broker");
  client.subscribe(MQTT_TOPIC, { qos: 0 }, (err) => {
    if (err) console.error("Subscribe error:", err);
  });
});

// Handle incoming MQTT messages (main data topic)
client.on("message", async (topic, message) => {
  if (topic === MQTT_TOPIC) {
    try {
      latestData = JSON.parse(message.toString());
      const now = new Date();
      
      // Data retention policy: Only log data every 30 seconds instead of every second
      // This reduces database size by 30x
      const shouldLog = Math.floor(now.getTime() / 30000) % 1 === 0; // Log every 30 seconds
      
      if (shouldLog) {
        // Log Motor data to MongoDB
        if (latestData.MOTORS) {
          for (const [name, data] of Object.entries(latestData.MOTORS)) {
            let runtimeValue = "";
            if (typeof data.Runtime === "string") {
              runtimeValue = data.Runtime;
            } else if (typeof data.Runtime === "number") {
              // Convert seconds to hh:mm:ss string
              const h = String(Math.floor(data.Runtime / 3600)).padStart(2, "0");
              const m = String(Math.floor((data.Runtime % 3600) / 60)).padStart(
                2,
                "0"
              );
              const s = String(data.Runtime % 60).padStart(2, "0");
              runtimeValue = `${h}:${m}:${s}`;
            }
            await MotorLog.create({
              timestamp: now,
              name: name,
              Speed: data.Speed,
              RunFeedback: data.RunFeedback,
              Runtime: runtimeValue,
              Fault: data.Fault,
            });
          }
        }
        // Log Valve data
        if (latestData.VALVES) {
          for (const [name, data] of Object.entries(latestData.VALVES)) {
            await ValveLog.create({
              timestamp: now,
              name: name,
              OpenFeedback: data.OpenFeedback,
              ValvePosition: data.ValvePosition,
              Fault: data.Fault,
            });
          }
        }
        // Log Damper data
        if (latestData.DAMPERS) {
          for (const [name, data] of Object.entries(latestData.DAMPERS)) {
            await DamperLog.create({
              timestamp: now,
              name: name,
              OpenFeedback: data.OpenFeedback,
              DamperPosition: data.DamperPosition,
              Fault: data.Fault,
            });
          }
        }
        // Log AHU, Chiller, Boiler data
        if (latestData.AHU) {
          await AHULog.create({
            timestamp: now,
            name: "AHU",
            data: latestData.AHU,
          });
        }
        if (latestData.CHILLER) {
          await ChillerLog.create({
            timestamp: now,
            name: "CHILLER",
            data: latestData.CHILLER,
          });
        }
        if (latestData.BOILER) {
          await BoilerLog.create({
            timestamp: now,
            name: "BOILER",
            data: latestData.BOILER,
          });
        }
      }
      
      // Broadcast latest data to all connected clients (always broadcast for real-time display)
      io.emit("socketPackages", latestData);
    } catch (e) {
      console.error("JSON parse error:", e);
    }
  }
});

// --- Socket.IO: Handle control commands from clients ---
io.on("connection", (socket) => {
  socket.on("control", (msg) => {
    // msg: { device, property, value }
    try {
      // Forward control command to MQTT for PLC/field devices
      client.publish("HVAC_control", JSON.stringify(msg), { qos: 1 });
      console.log("Forwarded control command:", msg);
    } catch (err) {
      console.error("Error forwarding control command:", err);
    }
  });
});

// --- MongoDB connection ---
const dbURI = process.env.MONGODB_URI;
mongoose
  .connect(dbURI)
  .then(() => {
    console.log("Database connected");
    server.listen(PORT, () => {
      console.log(`Server is running http://localhost:${PORT}/dashboard`);
    });
  })
  .catch((err) => console.log(err));

// --- Routes ---
app.get("/", (req, res) => res.render("home"));
app.use(authRouters);
app.use("/dashboard", requireAuth, dashboardRoutes);
app.use("/chart", requireAuth, chartRoutes);
app.use("/reporting", requireAuth, reportingRoutes);


// Thêm route API trực tiếp cho motor speed data
app.get("/api/motor-speed/:duration", requireAuth, (req, res) => {
  const chartController = require('./controllers/chartController');
  chartController.getMotorSpeedData(req, res);
});

// Thêm route API trực tiếp cho latest motor speed
app.get("/api/motor-speed/latest", requireAuth, (req, res) => {
  const chartController = require('./controllers/chartController');
  chartController.getLatestMotorSpeed(req, res);
});

app.use("/data-lookup", requireAuth, dataLookupRoutes);
app.use("/data-lookup/api", requireAuth, dataLookupRoutes);
app.use((req, res, next) => {
  const publicRoutes = ["/", "/login", "/signup", "/logout"];
  if (publicRoutes.includes(req.path) || req.path.startsWith("/public/")) {
    return next();
  }
  if (!req.user) {
    return res.redirect("/");
  }
  next();
});
