# ShopwareX API - Swagger Documentation Setup

## Tổng quan

Dự án ShopwareX đã được cấu hình hoàn chỉnh với Swagger/OpenAPI để cung cấp documentation tự động cho REST API.

## Các tính năng Swagger đã cấu hình

### 1. **JWT Authentication Integration**

- Swagger UI hỗ trợ JWT authentication
- Có button "Authorize" để nhập JWT token
- Tự động thêm Bearer token vào các request

### 2. **API Documentation**

- Metadata đầy đủ cho API (title, description, version, contact, license)
- Documentation cho từng endpoint với:
  - Summary và description chi tiết
  - Thông tin về parameters
  - Response codes và schemas
  - Examples và descriptions

### 3. **Enhanced Swagger UI**

- Swagger UI được serve tại root URL (`/`)
- Display request duration
- Deep linking support
- Filter functionality
- Validation support

## Cách sử dụng

### 1. **Khởi động ứng dụng**

```bash
cd ShopwareX
dotnet run
```

### 2. **Truy cập Swagger UI**

- URL: `https://localhost:[port]/` hoặc `http://localhost:[port]/`
- Swagger JSON endpoint: `https://localhost:[port]/swagger/v1/swagger.json`

### 3. **Sử dụng JWT Authentication**

#### Bước 1: Login để lấy JWT token

1. Tìm endpoint `POST /api/auth/login`
2. Click "Try it out"
3. Nhập thông tin login:

```json
{
  "email": "user@example.com",
  "password": "your_password"
}
```

4. Click "Execute"
5. Copy JWT token từ response

#### Bước 2: Authorize với JWT token

1. Click button "Authorize" (🔒) ở đầu trang
2. Nhập: `Bearer YOUR_JWT_TOKEN_HERE`
3. Click "Authorize"
4. Click "Close"

#### Bước 3: Test các protected endpoints

- Giờ bạn có thể test các endpoint cần authentication
- JWT token sẽ tự động được thêm vào headers

## Cấu trúc API

### **Authentication**

- `POST /api/auth/login` - User login và lấy JWT token

### **User Management**

- `POST /api/user/add` - Đăng ký user mới (public)
- `GET /api/user/all` - Lấy tất cả users (Admin only)
- `GET /api/user/get/{id}` - Lấy user theo ID (Admin, User)
- `PUT /api/user/update/{id}` - Cập nhật user (User only)
- `DELETE /api/user/delete/{id}` - Xóa user (User only)

### **Role-based Access Control**

- **Super Admin**: Quản lý roles của users
- **Admin**: Quản lý categories và products, xem tất cả users
- **User**: Đặt hàng products, quản lý thông tin cá nhân

## Các packages đã thêm

```xml
<PackageReference Include="Swashbuckle.AspNetCore" Version="8.1.1" />
<PackageReference Include="Swashbuckle.AspNetCore.Annotations" Version="8.1.1" />
```

## Cấu hình XML Documentation

File csproj đã được cấu hình để generate XML documentation:

```xml
<GenerateDocumentationFile>true</GenerateDocumentationFile>
<DocumentationFile>bin\Debug\net8.0\ShopwareX.xml</DocumentationFile>
```

## Troubleshooting

### 1. **Swagger UI không hiển thị**

- Kiểm tra ứng dụng đang chạy ở Development environment
- Verify URL và port number

### 2. **JWT Authentication không hoạt động**

- Đảm bảo đã login và copy đúng JWT token
- Kiểm tra token format: `Bearer <token>`
- Verify token chưa expire

### 3. **403 Forbidden errors**

- Kiểm tra user có đúng role không
- Verify JWT token hợp lệ
- Xem lại role requirements cho endpoint

## Tùy chỉnh thêm

### Thêm documentation cho controller khác

```csharp
[SwaggerTag("Description của controller")]
public class YourController : ControllerBase
{
    /// <summary>
    /// Mô tả ngắn gọn về endpoint
    /// </summary>
    /// <param name="param">Mô tả parameter</param>
    /// <returns>Mô tả return value</returns>
    /// <response code="200">Success description</response>
    /// <response code="400">Error description</response>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Tóm tắt endpoint",
        Description = "Mô tả chi tiết endpoint",
        OperationId = "UniqueOperationId"
    )]
    [SwaggerResponse(200, "Success", typeof(ResponseType))]
    [SwaggerResponse(400, "Bad Request")]
    public async Task<ActionResult> YourMethod([FromQuery] string param)
    {
        // Implementation
    }
}
```

### Thêm API versioning

```csharp
builder.Services.AddApiVersioning();
builder.Services.AddVersionedApiExplorer();
```

## Best Practices

1. **Luôn thêm summary và description cho endpoints**
2. **Specify response types và codes**
3. **Document parameters và models**
4. **Sử dụng consistent naming conventions**
5. **Thêm examples cho complex requests**
6. **Keep documentation up-to-date with code changes**

## Liên kết hữu ích

- [Microsoft ASP.NET Core OpenAPI Documentation](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger)
- [Swashbuckle.AspNetCore GitHub](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [OpenAPI Specification](https://swagger.io/specification/)
