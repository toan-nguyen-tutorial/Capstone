# Chiller & Boiler Temperature Charts

## Overview
Đã thêm 2 line chart mới vào trang Chart để hiển thị dữ liệu nhiệt độ của Chiller và Boiler:

1. **Chiller Temperature Chart**: Hiển thị Chiller Temp Out và Cooling Tower Temp Out
2. **Boiler Temperature Chart**: Hiển thị Boiler Temp Out và Heat Exchanger Temp Out

## Tính năng

### Chiller Temperature Chart
- **Chiller Temp Out**: Nhiệt độ đầu ra của chiller (màu đỏ)
- **Cooling Tower Temp Out**: Nhiệt độ đầu ra của cooling tower (màu xanh)
- Thang đo: 0-50°C
- Cập nhật real-time qua Socket.IO

### Boiler Temperature Chart
- **Boiler Temp Out**: Nhiệt độ đầu ra của boiler (màu cam)
- **Heat Exchanger Temp Out**: Nhiệt độ đầu ra của heat exchanger (màu tím)
- Thang đo: 0-100°C
- Cập nhật real-time qua Socket.IO

## Controls

### Period Settings
- **1 giây**: Cập nhật mỗi giây
- **5 giây**: Cập nhật mỗi 5 giây
- **10 giây**: Cập nhật mỗi 10 giây

### Time Buffer
- **1 phút**: Hiển thị dữ liệu 1 phút gần nhất
- **5 phút**: Hiển thị dữ liệu 5 phút gần nhất

### Timer Display
- Hiển thị thời gian còn lại đến lần cập nhật tiếp theo
- Tự động reset khi thay đổi settings

## API Endpoints

### Chiller Temperature Data
```
GET /chart/api/chiller-temp/:duration
```
- `duration`: Thời gian tính bằng phút (1, 5)
- Trả về: `{ timestamp, chillerTempOut, coolingTowerTempOut }`

### Boiler Temperature Data
```
GET /chart/api/boiler-temp/:duration
```
- `duration`: Thời gian tính bằng phút (1, 5)
- Trả về: `{ timestamp, boilerTempOut, heatExchangerTempOut }`

## Data Structure

### Chiller Data (Socket.IO)
```javascript
{
  CHILLER: {
    ChillerTempOut: number,        // Nhiệt độ chiller (°C)
    CoolingTowerTempOut: number,   // Nhiệt độ cooling tower (°C)
    // ... other fields
  }
}
```

### Boiler Data (Socket.IO)
```javascript
{
  BOILER: {
    BoilerTemperatureOutput: number,           // Nhiệt độ boiler (°C)
    HeatExchangerTemperatureOutput: number,    // Nhiệt độ heat exchanger (°C)
    // ... other fields
  }
}
```

## Persistent Settings

### Lưu trữ tự động
- Period settings được lưu vào localStorage
- Time buffer settings được lưu vào localStorage
- Khôi phục tự động khi refresh trang

### Reset Settings
- Nút "Reset Settings" xóa tất cả settings đã lưu
- Khôi phục về giá trị mặc định

## Layout

### Chiller Section
- Icon: `bi-thermometer-half`
- Background: `#1e2f3d`
- Chart: Full width (col-10)

### Boiler Section
- Icon: `bi-fire`
- Background: `#1e2f3d`
- Chart: Full width (col-10)

## Chart Features

### Time Axis
- Hiển thị thời gian theo định dạng HH:MM:SS
- Tự động điều chỉnh số lượng tick dựa trên period và duration
- Major ticks cho các điểm thời gian quan trọng

### Temperature Axis
- **Chiller**: 0-50°C, step size 5°C
- **Boiler**: 0-100°C, step size 10°C
- Auto-scaling dựa trên dữ liệu

### Line Styling
- Smooth curves với tension 0.4
- No point radius để tối ưu performance
- Border width 2px cho dễ nhìn
- Semi-transparent background

## Real-time Updates

### Socket.IO Integration
- Nhận dữ liệu real-time từ MQTT broker
- Cập nhật chart theo timer settings
- Buffer dữ liệu để hiển thị lịch sử

### Data Processing
- Lấp đầy dữ liệu thiếu bằng interpolation
- Tự động cập nhật time series
- Xử lý dữ liệu null/undefined

## Performance

### Optimization
- Chart animation disabled để tăng performance
- Efficient data buffering
- Minimal DOM updates
- Optimized timer management

### Memory Management
- Automatic cleanup of old data
- Efficient array operations
- Proper event listener cleanup

## Troubleshooting

### Chart không hiển thị
1. Kiểm tra MongoDB connection
2. Kiểm tra MQTT data flow
3. Kiểm tra console errors
4. Verify API endpoints

### Dữ liệu không cập nhật
1. Kiểm tra Socket.IO connection
2. Verify timer settings
3. Check MQTT topic subscription
4. Monitor network connectivity

### Performance issues
1. Giảm update frequency
2. Giảm time buffer
3. Kiểm tra browser performance
4. Monitor memory usage

## Testing

### Manual Testing
1. Thay đổi Period settings
2. Thay đổi Time Buffer settings
3. Refresh trang để test persistence
4. Test Reset Settings button

### Data Validation
1. Verify temperature ranges
2. Check timestamp accuracy
3. Validate data consistency
4. Monitor real-time updates

## Future Enhancements

### Planned Features
- Temperature alarms/thresholds
- Export data functionality
- Advanced filtering options
- Custom time ranges
- Data analytics tools

### Potential Improvements
- Multiple chart types (bar, area)
- Zoom and pan functionality
- Data annotation
- Trend analysis
- Alert notifications 