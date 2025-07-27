# Chart Page - Persistent Settings Feature

## Overview
Tính năng lưu trạng thái (persistent settings) đã được thêm vào trang Chart để giữ nguyên các lựa chọn của người dùng khi refresh trang hoặc đóng/mở lại trình duyệt.

## Tính năng được lưu trữ

### 1. Checkbox Selections
- **Motor checkboxes**: Lưu trạng thái checked/unchecked của các motor được chọn
- **Valve checkboxes**: Lưu trạng thái checked/unchecked của các valve được chọn  
- **Damper checkboxes**: Lưu trạng thái checked/unchecked của các damper được chọn

### 2. Gauge Selections
- **Motor gauge**: Lưu motor được chọn để hiển thị trên gauge
- **Valve gauge**: Lưu valve được chọn để hiển thị trên gauge
- **Damper gauge**: Lưu damper được chọn để hiển thị trên gauge

### 3. Control Settings
- **Period settings**: Lưu chu kỳ cập nhật dữ liệu (1, 5, 10 giây)
- **Duration settings**: Lưu thời gian buffer dữ liệu (1, 5 phút)

## Cách hoạt động

### Lưu trữ dữ liệu
- Sử dụng `localStorage` của trình duyệt để lưu trữ
- Dữ liệu được lưu dưới dạng JSON string
- Tự động lưu khi người dùng thay đổi bất kỳ setting nào

### Khôi phục dữ liệu
- Tự động khôi phục khi trang được load
- Nếu không có dữ liệu đã lưu, sử dụng giá trị mặc định
- Đối với checkbox: mặc định chọn 2 thiết bị đầu tiên

### Các key localStorage được sử dụng
```javascript
// Checkbox states
'motorSelectedDevices'     // Array of selected motor names
'valveSelectedDevices'     // Array of selected valve names  
'damperSelectedDevices'    // Array of selected damper names

// Gauge selections
'selectedGaugeMotor'       // Selected motor for gauge display
'selectedGaugeValve'       // Selected valve for gauge display
'selectedGaugeDamper'      // Selected damper for gauge display

// Control settings
'motorDuration'           // Motor time buffer setting
'motorUpdatePeriod'       // Motor update period setting
'valveDuration'          // Valve time buffer setting
'valveUpdatePeriod'      // Valve update period setting
'damperDuration'         // Damper time buffer setting
'damperUpdatePeriod'     // Damper update period setting
```

## Reset Settings

### Nút Reset
- Nút "Reset Settings" ở góc trên bên phải của trang
- Xóa tất cả dữ liệu đã lưu và khôi phục về mặc định
- Hiển thị confirm dialog trước khi reset

### Reset thủ công
Có thể xóa dữ liệu thủ công bằng cách:
1. Mở Developer Tools (F12)
2. Vào tab Application/Storage
3. Chọn Local Storage
4. Xóa các key liên quan đến chart

## Lợi ích

### Cho người dùng
- Không cần chọn lại các thiết bị mỗi khi refresh trang
- Gauge selection được giữ nguyên
- Settings được ghi nhớ giữa các phiên làm việc
- Tiết kiệm thời gian setup

### Cho hệ thống
- Tăng trải nghiệm người dùng
- Giảm thao tác lặp lại
- Dữ liệu được lưu locally, không ảnh hưởng server

## Lưu ý kỹ thuật

### Browser Compatibility
- Hoạt động trên tất cả trình duyệt hiện đại
- localStorage có sẵn từ IE8+
- Dữ liệu được lưu theo domain

### Data Persistence
- Dữ liệu tồn tại cho đến khi:
  - Người dùng xóa browser data
  - Sử dụng nút Reset Settings
  - Xóa thủ công qua Developer Tools

### Performance
- Lưu trữ local, không ảnh hưởng network
- Khôi phục nhanh khi load trang
- Không tăng kích thước request/response

## Troubleshooting

### Nếu settings không được lưu
1. Kiểm tra localStorage có được enable không
2. Kiểm tra browser có hỗ trợ localStorage không
3. Kiểm tra console có lỗi JavaScript không

### Nếu settings không được khôi phục
1. Kiểm tra dữ liệu trong localStorage
2. Refresh trang và thử lại
3. Sử dụng nút Reset Settings để reset về mặc định

### Xóa dữ liệu cụ thể
```javascript
// Xóa chỉ motor selections
localStorage.removeItem('motorSelectedDevices');

// Xóa chỉ gauge selections  
localStorage.removeItem('selectedGaugeMotor');
localStorage.removeItem('selectedGaugeValve');
localStorage.removeItem('selectedGaugeDamper');

// Xóa tất cả chart data
localStorage.clear();
``` 