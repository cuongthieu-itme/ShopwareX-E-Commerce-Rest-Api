<div>
  <h1>
    ShopwareX E-Commerce REST API
  </h1>
</div>

<div>
  <p>
    "ShopwareX" is a REST API for e-commerce system with comprehensive Swagger/OpenAPI documentation. System contains 3 roles: Super admin, admin and user. Super admin manages roles of users. Admin manages categories and products. Users order products. You can enter count of product which you want to order. And system calculate final amount and return it to you. There are registration and login functionalities in the system. For example, if user want to order product, he/she must register in system. Then he/she must login. After logged in user can order products. Authentication service had been made implementing JWT. User sends request to "/login" endpoint and API gives response which contains Json Web Token. User includes this JWT and get access to operation.
  </p>
</div>

## 🚀 Quick Start

### Prerequisites

- .NET 8.0 SDK
- MySQL Server
- Visual Studio Code / Visual Studio / Rider

### Installation

1. **Clone the repository**

```bash
git clone https://github.com/your-repo/ShopwareX-E-Commerce-Rest-Api.git
cd ShopwareX-E-Commerce-Rest-Api
```

2. **Configure Database**

   - Update connection string in `appsettings.Development.json`
   - Run database migrations

3. **Build and Run**

```bash
cd ShopwareX
dotnet build
dotnet run
```

4. **Access Swagger Documentation**
   - Navigate to: `https://localhost:[port]/` or `http://localhost:[port]/`
   - The Swagger UI will be displayed automatically

## 📚 API Documentation

### Swagger/OpenAPI Features

- ✅ **Complete API Documentation** with detailed descriptions
- ✅ **JWT Authentication Integration** - Built-in "Authorize" button
- ✅ **Interactive Testing** - Test endpoints directly from browser
- ✅ **Request/Response Examples** with proper schemas
- ✅ **Role-based Access Control** documentation
- ✅ **Real-time API Exploration**

### How to Use Swagger

1. **Start the application** (`dotnet run`)
2. **Open browser** and go to the root URL (Swagger UI loads automatically)
3. **Login to get JWT token**:
   - Use `POST /api/auth/login` endpoint
   - Copy the JWT token from response
4. **Authorize**:
   - Click the "Authorize" 🔒 button at the top
   - Enter: `Bearer YOUR_JWT_TOKEN`
   - Click "Authorize"
5. **Test protected endpoints** - JWT token is automatically included

### API Endpoints

#### 🔐 Authentication

- `POST /api/auth/login` - User login and JWT token generation

#### 👥 User Management

- `POST /api/user/add` - Register new user (public)
- `GET /api/user/all` - Get all users (Admin only)
- `GET /api/user/get/{id}` - Get user by ID (Admin, User)
- `PUT /api/user/update/{id}` - Update user (User only)
- `DELETE /api/user/delete/{id}` - Delete user (User only)

#### 📦 Product Management

- `GET /api/product/all` - Get all products
- `GET /api/product/get/{id}` - Get product by ID
- `POST /api/product/add` - Add new product (Admin only)
- `PUT /api/product/update/{id}` - Update product (Admin only)
- `DELETE /api/product/delete/{id}` - Delete product (Admin only)

#### 📂 Category Management

- `GET /api/category/all` - Get all categories
- `GET /api/category/get/{id}` - Get category by ID
- `POST /api/category/add` - Add new category (Admin only)
- `PUT /api/category/update/{id}` - Update category (Admin only)
- `DELETE /api/category/delete/{id}` - Delete category (Admin only)

#### 🛒 Order Management

- `GET /api/order/all` - Get all orders (Admin only)
<div>
  <h1>
    Tech Stack
  </h1>
</div>

<div>
  <ul>
    <li>C#</li>
    <li>OOP</li>
    <li>DTO</li>
    <li>ORM</li>
    <li>LINQ</li>
    <li>MySQL</li>
    <li>AutoMapper</li>
  </ul>
</div>
# ShopwareX-E-Commerce-Rest-Api
