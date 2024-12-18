# ContosoPizza

## Overview
**ContosoPizza** is a lightweight RESTful API for managing a pizza store, built with **ASP.NET Core Web API**. The project provides CRUD operations to manage pizza data, utilizes **Entity Framework Core (EF Core)** for database interactions, and employs **SQL Server** as the database.

---

## Features
- Create, Read, Update, and Delete (CRUD) operations for pizzas.
- Secure API endpoints with JWT authentication.
- Database migration and schema management with EF Core.
- Separation of concerns through DTOs and Controllers.

---

## Project Structure

```
ContosoPizza
├── Controllers
│   ├── PizzaController.cs           # Handles pizza-related endpoints
│   └── TokenGenerationJWTController.cs # Manages JWT token generation
├── DTOs
│   ├── CreatePizzaDto.cs           # DTO for creating a pizza
│   ├── PizzaDto.cs                 # DTO for pizza details
│   └── UpdatePizzaDto.cs           # DTO for updating a pizza
├── Data
│   ├── PizzaDbContext.cs           # EF Core database context
│   ├── Migrations                  # Auto-generated migration files
│   └── PizzaDbContextModelSnapshot.cs # Snapshot for EF Core migrations
├── Entities
│   └── Pizza.cs                    # Entity model for pizza
├── appsettings.json                # Application configuration
├── Program.cs                      # Entry point of the API
├── ContosoPizza.csproj             # Project file
└── ContosoPizza.sln                # Solution file
```

---

## Prerequisites

- **.NET 6.0 SDK or later**
- **SQL Server**
- **Visual Studio 2022** or any IDE that supports .NET development

---

## Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-repo/ContosoPizza.git
   cd ContosoPizza
   ```

2. **Configure the Database**
   - Update the `ConnectionStrings` in `appsettings.json` with your SQL Server credentials.

3. **Apply Migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the Application**
   ```bash
   dotnet run
   ```
   The API will be available at `http://localhost:5000` by default.

---

## Endpoints

### Pizza Endpoints
| Method | Endpoint       | Description             |
|--------|----------------|-------------------------|
| GET    | /api/pizzas    | Retrieve all pizzas     |
| GET    | /api/pizzas/{id}| Retrieve a single pizza |
| POST   | /api/pizzas    | Create a new pizza      |
| PUT    | /api/pizzas/{id}| Update a pizza          |
| DELETE | /api/pizzas/{id}| Delete a pizza          |

### Authentication Endpoint
| Method | Endpoint          | Description                  |
|--------|-------------------|------------------------------|
| POST   | /api/authenticate | Generate JWT authentication token |

---

## Technologies Used
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **JWT Authentication**

---

## Contribution
Feel free to fork the repository and submit a pull request for any improvements or bug fixes.
