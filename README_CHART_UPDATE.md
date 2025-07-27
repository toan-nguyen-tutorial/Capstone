# Chart Page Updates

## Overview
The chart page has been updated to include three separate sections for Motor, Valve, and Damper monitoring, each with their own real-time charts and gauges.

## New Features

### 1. Three-Row Layout
- **Motor Section**: Top row with motor speed monitoring
- **Valve Section**: Middle row with valve position monitoring (Valve_1 to Valve_20)
- **Damper Section**: Bottom row with damper position monitoring (Damper_1 to Damper_5)

### 2. Independent Controls
Each section has its own:
- Period selector (1s, 5s, 10s)
- Time buffer selector (1 minute, 5 minutes)
- Device selection dropdown with checkboxes
- Timer countdown display

### 3. Real-time Charts
- **Motor Chart**: Shows motor speed in RPM (0-1000 range)
- **Valve Chart**: Shows valve position in percentage (0-100 range)
- **Damper Chart**: Shows damper position in percentage (0-100 range)

### 4. Gauge Indicators
Each section has its own gauge:
- **Motor Gauge**: Shows current speed with status (Normal/Warning/Critical)
- **Valve Gauge**: Shows current position with status (Normal/Warning/Critical)
- **Damper Gauge**: Shows current position with status (Normal/Warning/Critical)

### 5. Data Sources
- **Motor Data**: Uses existing MOTORS data from Socket.IO
- **Valve Data**: Uses existing VALVES data from Socket.IO (Valve_1 to Valve_20)
- **Damper Data**: Uses existing DAMPERS data from Socket.IO (Damper_1 to Damper_5)

## API Endpoints
- `/chart/api/motor-speed/:duration` - Motor speed historical data
- `/chart/api/valve-position/:duration` - Valve position historical data
- `/chart/api/damper-position/:duration` - Damper position historical data

## Usage
1. Navigate to `/chart` page
2. Each section operates independently
3. Select devices using the dropdown checkboxes
4. Adjust period and time buffer as needed
5. Monitor real-time data in charts and gauges

## Technical Details
- All charts use Chart.js with custom plugins for grid and ticks
- Gauges use D3.js with custom styling
- Real-time updates via Socket.IO
- Historical data fetched from MongoDB via REST API
- Responsive design with Bootstrap 5 