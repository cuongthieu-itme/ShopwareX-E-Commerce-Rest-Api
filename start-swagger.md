# Khởi động nhanh ShopwareX với Swagger

## 1. Kiểm tra Prerequisites

Đảm bảo bạn đã cài đặt:

- ✅ .NET 8.0 SDK
- ✅ MySQL Server đang chạy

## 2. Khởi động ứng dụng

```bash
cd ShopwareX
dotnet run
```

## 3. Truy cập Swagger UI

Mở browser và truy cập:

- **HTTPS**: `https://localhost:7285/` (hoặc port được hiển thị trong console)
- **HTTP**: `http://localhost:5049/` (hoặc port được hiển thị trong console)

Swagger UI sẽ hiển thị ngay lập tức!

## 4. Test API với Swagger

### Bước 1: Test endpoint công khai

1. Tìm section **Auth** trong Swagger UI
2. Click vào `POST /api/auth/login`
3. Click **"Try it out"**
4. Nhập dữ liệu test:

```json
{
  "email": "test@example.com",
  "password": "password123"
}
```

5. Click **Execute**

### Bước 2: Authorize với JWT (nếu login thành công)

1. Copy JWT token từ response
2. Click nút **"Authorize"** 🔒 ở đầu trang Swagger
3. Nhập: `Bearer YOUR_JWT_TOKEN_HERE`
4. Click **"Authorize"** và **"Close"**

### Bước 3: Test protected endpoints

Giờ bạn có thể test các endpoint cần authorization như:

- `GET /api/user/all` (Admin only)
- `GET /api/user/get/{id}` (Admin, User)
- etc.

## 5. Các tính năng Swagger đã được cấu hình

✅ **JWT Authentication Integration**

- Button "Authorize" để nhập JWT token
- Tự động thêm Bearer token vào headers

✅ **Complete API Documentation**

- Mô tả chi tiết cho mỗi endpoint
- Information về parameters và responses
- Response examples với status codes

✅ **Enhanced Swagger UI**

- Hiển thị tại root URL (`/`)
- Deep linking support
- Request duration display
- Filter functionality

✅ **Role-based Documentation**

- Thông tin về roles cần thiết cho mỗi endpoint
- Error responses cho unauthorized access

## 6. Troubleshooting

### Nếu Swagger UI không hiển thị:

- Kiểm tra console để xem port chính xác
- Đảm bảo ứng dụng đang chạy ở Development environment
- Verify URL format: `https://localhost:PORT/` hoặc `http://localhost:PORT/`

### Nếu database connection failed:

- Kiểm tra MySQL server đang chạy
- Verify connection string trong `appsettings.Development.json`
- Chạy migrations nếu cần: `dotnet ef database update`

### Nếu JWT authorization không hoạt động:

- Đảm bảo đã login thành công trước
- Copy đúng JWT token (không có quotes)
- Format: `Bearer <space>TOKEN`
- Kiểm tra token chưa expire (default 60 minutes)

## 7. Demo Data

Để test đầy đủ, bạn có thể cần:

1. Tạo một số user với các roles khác nhau
2. Tạo categories và products
3. Test order workflow

Tất cả có thể được thực hiện trực tiếp từ Swagger UI!

---

**🎉 Chúc mừng! Swagger đã được cấu hình hoàn chỉnh cho ShopwareX API!**
