# 📝 TodoApp: ASP.NET Core REST API with Blazor WebAssembly Frontend

## 🌟 **Tổng quan**

TodoApp là một dự án kết hợp sức mạnh của **ASP.NET Core REST API** và **Blazor WebAssembly** để cung cấp một giải pháp toàn diện cho việc quản lý công việc. Backend đóng vai trò cung cấp API, trong khi frontend mang lại giao diện hiện đại và tương tác cho người dùng.

---

## 🛠️ **Công nghệ sử dụng**

### Backend (ASP.NET Core REST API)

- **ASP.NET Core 9.0**
- **Entity Framework Core** cho thao tác cơ sở dữ liệu
- **FluentValidation** để kiểm tra hợp lệ mô hình
- **AutoMapper** để ánh xạ DTO
- **Swagger** cho tài liệu API
- Một instance SQL Server (local hoặc cloud)

### **2. Clone Repository:**

```bash
git clone https://github.com/TVinhNguyen/TodoApp.git

```

### **3. Cài đặt Backend:**

1. Di chuyển đến thư mục API:
   ```bash
   cd TodoApp
   ```
2. Cài đặt các package:
   ```bash
   dotnet restore
   ```
3. Áp dụng migrations và khởi tạo cơ sở dữ liệu:
   ```bash
   dotnet ef database update
   ```
4. Chạy API:
   ```bash
   dotnet run
   ```
   API sẽ hoạt động tại `http://localhost:5289`.

### **4. Cài đặt Frontend:**

1. Di chuyển đến thư mục Blazor:
   ```bash
   cd TodoBlazor
   ```
2. Cài đặt các package:
   ```bash
   dotnet restore
   ```
3. Chạy ứng dụng frontend:
   ```bash
   dotnet run
   ```
   Frontend sẽ hoạt động tại `http://localhost:5226`.

---

## 📂 **Cấu trúc dự án**

### Backend (API)

```plaintext
TodoApp.Api/
├── Controllers/          # REST API Controllers
├── DTOs/                 # Data Transfer Objects
├── Models/               # Entity Models
├── Repositories/         # Data Access Layer
├── Services/             # Business Logic Layer
├── Middlewares/          # Custom Middleware
├── Mappings/             # AutoMapper Profiles
├── Program.cs            # Entry Point
├── appsettings.json      # Configuration
```

### Frontend (Blazor WebAssembly)

```plaintext
TodoAppFrontend/
├── wwwroot/              # Static Files
├── Component/            # Layout , Pages , Application Root
├── Models/               # Todo Model
├── Services/             # API Service Layer
├── Program.cs            # Entry Point
```

---

## 🌐 **API Endpoints**

### **Todos**

| ⚡ Method | 🛣️ Endpoint       | 📝 Description              |
|----------|-------------------|----------------------------|
| GET      | /api/todos        | Lấy danh sách tất cả tasks |
| GET      | /api/todos/{id}   | Lấy thông tin chi tiết     |
| POST     | /api/todos        | Tạo task mới               |
| PUT      | /api/todos/{id}   | Cập nhật task              |
| DELETE   | /api/todos/{id}   | Xóa task                   |

---

## 🖼️ **Ảnh minh họa**

### Frontend

- **Trang chủ:**
  Hiển thị danh sách todos.
- **Thêm/Sửa Task:**
  Form để tạo hoặc chỉnh sửa tasks.
- **Xác nhận xóa:**
  Hiển thị trước khi xóa tasks.

### API

- **Swagger UI:**

---

## 🤝 **Đóng góp**

Đóng góp luôn được chào đón! Vui lòng thực hiện các bước sau:

1. Fork repository.
2. Tạo một nhánh mới:
   ```bash
   git checkout -b feature-name
   ```
3. Commit thay đổi của bạn:
   ```bash
   git commit -m "Thêm mô tả tính năng"
   ```
4. Push lên nhánh của bạn:
   ```bash
   git push origin feature-name
   ```
5. Tạo pull request.

---

## 📬 **Liên hệ**


- ✉️ **Email:** [vinhgrh3@gmail.com](mailto:vinhgrh3@gmail.com)
- 🐙 **GitHub:** [TVinhNguyen](https://github.com/TVinhNguyen)

