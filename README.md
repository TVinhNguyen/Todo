# TodoApp: ASP.NET Core REST API with Blazor WebAssembly Frontend

## **Overview**

TodoApp is a comprehensive project that combines the power of **ASP.NET Core REST API** and **Blazor WebAssembly** to provide a full-stack solution for managing tasks. The backend serves as the API provider, while the frontend offers a modern, interactive UI for users.

---

## **Technologies Used**

### Backend (ASP.NET Core REST API)

- **ASP.NET Core 6.0**
- **Entity Framework Core** for database operations
- **FluentValidation** for model validation
- **AutoMapper** for DTO mapping
- **Serilog** for advanced logging
- **Swagger** for API documentation

### Frontend (Blazor WebAssembly)

- **Blazor WebAssembly** for client-side rendering
- **HttpClient** for API communication
- **Bootstrap 5** for styling

---

## **Features**

### Backend Features:

1. **CRUD Operations:** Fully implemented endpoints for managing Todos.
2. **Validation:** Middleware for request validation using FluentValidation.
3. **Error Handling:** Global exception handling middleware.
4. **Rate Limiting:** Prevents excessive requests from a single client.
5. **Caching:** In-memory caching for efficient data retrieval.
6. **Swagger Integration:** API documentation and testing.

### Frontend Features:

1. **Responsive UI:** A modern interface built with Blazor WebAssembly.
2. **Real-Time Data:** Fetch, create, update, and delete tasks directly from the REST API.
3. **Routing:** Smooth navigation with built-in routing.
4. **Reusable Components:** Blazor components for tasks and forms.

---

## **Installation and Setup**

### **1. Prerequisites:**

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [Node.js and npm](https://nodejs.org/) (if required for frontend tools)
- A SQL Server instance (local or cloud)

### **2. Clone the Repository:**

```bash
git clone https://github.com/yourusername/TodoApp.git
cd TodoApp
```

### **3. Setup Backend:**

1. Navigate to the API folder:
   ```bash
   cd TodoApp.Api
   ```
2. Install dependencies:
   ```bash
   dotnet restore
   ```
3. Apply migrations and initialize the database:
   ```bash
   dotnet ef database update
   ```
4. Run the API:
   ```bash
   dotnet run
   ```
   The API will be available at `https://localhost:5001`.

### **4. Setup Frontend:**

1. Navigate to the Blazor project folder:
   ```bash
   cd TodoAppFrontend
   ```
2. Install dependencies:
   ```bash
   dotnet restore
   ```
3. Run the frontend application:
   ```bash
   dotnet run
   ```
   The frontend will be available at `https://localhost:5002`.

---

## **Project Structure**

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
├── Pages/                # Blazor Pages
├── Shared/               # Shared Layout and Components
├── Models/               # Todo Model
├── Services/             # API Service Layer
├── Program.cs            # Entry Point
├── App.razor             # Application Root
```

---

## **API Endpoints**

### **Todos**

| Method | Endpoint        | Description              |
| ------ | --------------- | ------------------------ |
| GET    | /api/todos      | Retrieve all tasks       |
| GET    | /api/todos/{id} | Retrieve a specific task |
| POST   | /api/todos      | Create a new task        |
| PUT    | /api/todos/{id} | Update an existing task  |
| DELETE | /api/todos/{id} | Delete a task            |

---

## **Screenshots**

### Frontend

- **Home Page:**
  Displays a list of todos.
- **Add/Edit Task:**
  Forms for creating or updating tasks.
- **Delete Confirmation:**
  Prompts before deleting tasks.

### API

- **Swagger UI:**


---

## **Contributing**

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature-name
   ```
3. Commit your changes:
   ```bash
   git commit -m "Add feature description"
   ```
4. Push to your branch:
   ```bash
   git push origin feature-name
   ```
5. Create a pull request.

---

## **License**

This project is licensed under the [MIT License](LICENSE).

---

## **Contact**

For questions or feedback, please reach out:

- **Email:** [your-email@example.com](mailto\:your-email@example.com)
- **GitHub:** [yourusername](https://github.com/yourusername)

hãy viết bằng tiếng việt 
