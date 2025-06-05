# ShopwareX E-Commerce REST API

"ShopwareX" is a REST API for an e-commerce system with comprehensive Swagger/OpenAPI documentation. The system supports three roles: Super Admin, Admin, and User.

-   **Super Admin**: Manages user roles.
-   **Admin**: Manages categories and products.
-   **User**: Can browse products and place orders.

The API includes functionalities for user registration, login, product management, category management, and order processing. Authentication is handled using JWT (JSON Web Tokens).

## 🚀 Quick Start

Follow these instructions to set up and run the project on your local machine.

### Prerequisites

Before you begin, ensure you have the following installed:

-   **.NET 8.0 SDK** (or newer): [Download .NET](https://dotnet.microsoft.com/download)
-   **MySQL Server**: [Download MySQL](https://dev.mysql.com/downloads/mysql/)
-   **Git**: [Download Git](https://git-scm.com/downloads)
-   An IDE or code editor (e.g., Visual Studio, VS Code, Rider).

### Installation and Setup

1.  **Clone the Repository**

    ```bash
    git clone https://github.com/your-username/ShopwareX-E-Commerce-Rest-Api.git
    cd ShopwareX-E-Commerce-Rest-Api
    ```
    *(Replace `https://github.com/your-username/ShopwareX-E-Commerce-Rest-Api.git` with the actual URL of your repository if it's different.)*

2.  **Configure Database Connection**

    *   **Create a MySQL Database**: Before running the application, you need to create a database in your MySQL server. For example, you can name it `shopwarex_db`.
    *   **Update Connection String**: Open the `ShopwareX/appsettings.Development.json` file (or `ShopwareX/appsettings.json` if you are not in a development environment).
        Locate the `ConnectionStrings` section and update the `MySqlDbConnection` value with your MySQL server details (server address, database name, username, and password).

        Example:
        ```json
        {
          // ... other settings
          "ConnectionStrings": {
            "MySqlDbConnection": "server=localhost;database=shopwarex_db;user=your_mysql_user;password=your_mysql_password"
          },
          // ... other settings
        }
        ```

3.  **Navigate to Project Directory**

    ```bash
    cd ShopwareX
    ```

4.  **Restore .NET Local Tools**

    If the project uses .NET local tools (defined in `.config/dotnet-tools.json`), restore them:
    ```bash
    dotnet tool restore
    ```
    This step ensures that tools like `dotnet-ef` for Entity Framework Core migrations are available.

5.  **Apply Database Migrations**

    Run the following command to create the database schema based on the existing migrations:
    ```bash
    dotnet ef database update
    ```

6.  **Build the Project**

    ```bash
    dotnet build
    ```

7.  **Run the Application**

    ```bash
    dotnet run
    ```
    The application will typically start on `http://localhost:5257` (or another port configured in `ShopwareX/Properties/launchSettings.json`). The console output will indicate the listening URLs.

8.  **Access Swagger Documentation**

    Once the application is running, open your web browser and navigate to:
    `http://localhost:5257/swagger`

    The Swagger UI will be displayed, allowing you to explore and test the API endpoints.

## 📚 API Documentation (via Swagger/OpenAPI)

Our API is fully documented using Swagger/OpenAPI, providing an interactive way to explore and test endpoints.

### Swagger Features

-   ✅ **Complete API Documentation**: Detailed descriptions for all endpoints, parameters, and responses.
-   ✅ **JWT Authentication Integration**: A built-in "Authorize" button to easily add your JWT for testing protected endpoints.
-   ✅ **Interactive Testing**: Execute API requests directly from your browser.
-   ✅ **Request/Response Examples**: Clear examples and schemas for all data models.
-   ✅ **Role-based Access Control Visibility**: Endpoints are typically annotated or described with the required roles.

### How to Use Swagger for Testing

1.  **Start the application** (as described in step 7 above).
2.  **Open the Swagger UI** in your browser (e.g., `http://localhost:5257/swagger`).
3.  **Login to Obtain a JWT Token**:
    *   Find the `POST /api/auth/login` endpoint under the "Authentication" section.
    *   Expand it, click "Try it out", and provide valid user credentials in the request body.
    *   Execute the request. Copy the `token` from the response body.
4.  **Authorize Swagger UI**:
    *   At the top right of the Swagger page, click the "Authorize" 🔒 button.
    *   In the dialog, paste your JWT token into the "Value" field, prefixed with `Bearer ` (e.g., `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...`).
    *   Click "Authorize" and then "Close".
5.  **Test Protected Endpoints**: You can now try out other endpoints that require authentication. The JWT token will be automatically included in the request headers.

## API Endpoints Overview

*(This section provides a high-level overview. Refer to Swagger UI for complete details.)*

#### 🔐 Authentication

-   `POST /api/auth/login`: User login and JWT token generation.

#### 👥 User Management

-   `POST /api/user/add`: Register a new user (public).
-   `GET /api/user/all`: Get all users (Admin/Super Admin only).
-   `GET /api/user/get/{id}`: Get user by ID (Authenticated user for their own profile, Admin/Super Admin for others).
-   `PUT /api/user/update/{id}`: Update user (Authenticated user for their own profile).
-   `DELETE /api/user/delete/{id}`: Delete user (Authenticated user for their own profile, Admin/Super Admin for others).

#### 📦 Product Management

-   `GET /api/product/all`: Get all products (public).
-   `GET /api/product/get/{id}`: Get product by ID (public).
-   `POST /api/product/add`: Add new product (Admin only).
-   `PUT /api/product/update/{id}`: Update product (Admin only).
-   `DELETE /api/product/delete/{id}`: Delete product (Admin only).

#### 📂 Category Management

-   `GET /api/category/all`: Get all categories (public).
-   `GET /api/category/get/{id}`: Get category by ID (public).
-   `POST /api/category/add`: Add new category (Admin only).
-   `PUT /api/category/update/{id}`: Update category (Admin only).
-   `DELETE /api/category/delete/{id}`: Delete category (Admin only).

#### 🛒 Order Management

-   `POST /api/order/create`: Create a new order (User only).
-   `GET /api/order/all`: Get all orders (Admin/Super Admin only).
-   `GET /api/order/get/{id}`: Get order by ID (User for their own orders, Admin/Super Admin for all).
-   `GET /api/order/user/{userId}`: Get all orders for a specific user (User for their own orders, Admin/Super Admin for all).

## 🛠️ Tech Stack

-   **Backend**: C#, ASP.NET Core 8, Entity Framework Core 8
-   **Database**: MySQL
-   **Authentication**: JWT (JSON Web Tokens)
-   **API Documentation**: Swashbuckle (Swagger/OpenAPI)
-   **Mapping**: AutoMapper
-   **Password Hashing**: BCrypt.Net-Next
-   **Design Principles**: RESTful APIs, Repository Pattern, DTOs (Data Transfer Objects)

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request or open an Issue.

## 📝 License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details (if one exists).

