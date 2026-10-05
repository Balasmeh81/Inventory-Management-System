# Inventory Management System

An **ASP.NET Core MVC** inventory management project built with **C#**, **.NET 10**, **Entity Framework Core**, and **SQL Server**.

The application manages countries, cities, warehouses, items, users, and roles while applying a service-based structure, DTOs, ViewModels, Dependency Injection, asynchronous database operations, and role-based authorization.

## Features

- User sign-in and account management using **ASP.NET Core Identity**
- Role management and **role-based authorization**
- Admin, Manager, and Employee role support
- Country management with create, view, update, search, and delete operations
- City management linked to countries
- Warehouse management linked to cities
- Item management linked to warehouses
- Dashboard showing total users, warehouses, items, and warehouse overview information
- Search functionality for countries, cities, and warehouses
- Form validation using **Data Annotations**
- Asynchronous database operations using **Async/Await**
- DTO and entity mapping using **AutoMapper**
- Entity Framework Core migrations for database schema management
- Unique database indexes to help protect data integrity

## Technologies Used

- **C#**
- **.NET 10**
- **ASP.NET Core MVC**
- **Entity Framework Core**
- **ASP.NET Core Identity**
- **SQL Server**
- **LINQ**
- **AutoMapper**
- **Razor Views**
- **HTML5**
- **CSS3**
- **Bootstrap**
- **JavaScript**
- **Dependency Injection**
- **Async/Await**
- **Visual Studio**
- **Git & GitHub**

## Project Structure

The project follows the ASP.NET Core MVC pattern with additional separation of responsibilities through services, interfaces, DTOs, ViewModels, and data entities.

```text
InventoryManagementSystem/
│
├── Controllers/        # Handles HTTP requests and application flow
├── Services/           # Business logic and service interfaces
├── Models/             # DTOs, ViewModels, role and form models
├── data/               # Database entities, ApplicationUser, and DbContext
├── Views/              # Razor views for the user interface
├── Migrations/         # Entity Framework Core migrations
├── wwwroot/            # CSS, JavaScript, images, and static files
│
├── Program.cs          # Application configuration and dependency registration
└── appsettings.json    # Application and database configuration
```

Controllers use service interfaces for application operations, while services interact with the Entity Framework Core `DbContext`. Services are registered through ASP.NET Core Dependency Injection.

## Core Concepts Applied

- **MVC Architecture**
- **Object-Oriented Programming (OOP)**
- **Service Layer** and interface-based design
- **Dependency Injection**
- **Entity Framework Core** for database access
- **LINQ** for querying, filtering, ordering, and aggregation
- **Async/Await** for asynchronous database operations
- **ASP.NET Core Identity** for authentication and user management
- **Role-Based Authorization**
- **DTOs** and **ViewModels**
- **AutoMapper** for object mapping
- **Data Annotations** for validation
- **Entity Relationships**
- **Primary and Foreign Keys**
- **Unique and Composite Indexes**
- **Database Migrations**
- **CRUD Operations**
- **Search and Filtering**

## Database & Relationships

The application uses **SQL Server** with **Entity Framework Core** for data persistence.

Main application entities include:

- **Country**
- **City**
- **Warehouse**
- **Item**
- **ApplicationUser**

The main inventory relationship is:

```text
Country
   └── City
       └── Warehouse
           └── Item
```

Users can also be associated with a warehouse.

Unique indexes are used for values such as country names and composite values such as city names within a country, warehouse names within a city, and item names within a warehouse.

## Authentication & Authorization

The project uses **ASP.NET Core Identity** for authentication and role management.

Implemented functionality includes:

- User sign-in and sign-out
- User account creation
- Role creation, update, and deletion
- Assigning roles to users
- Role-based access control
- Custom access-denied page

The application supports **Admin**, **Manager**, and **Employee** roles, with authorization applied to inventory management areas.

## Dashboard

The dashboard provides a quick overview of the system, including:

- Total users
- Total warehouses
- Total items
- Warehouse name and city
- Number of items per warehouse
- Number of users associated with each warehouse

## How to Run the Project

### Prerequisites

Make sure you have the following installed:

- **.NET 10 SDK**
- **Visual Studio 2026** or another IDE with .NET 10 support
- **SQL Server**
- **SQL Server Management Studio (SSMS)**

### Setup

1. Clone the repository:

```bash
git clone https://github.com/Balasmeh81/Inventory-Management-System.git
```

2. Open `InventoryManagementSystem.sln` in Visual Studio.

3. Make sure SQL Server is running.

4. Check the connection string inside `appsettings.json`:

```json
"ConnectionStrings": {
  "InventoryConn": "Server=localhost;Database=InventoryManagement;Integrated Security=True;TrustServerCertificate=True;"
}
```

Update the connection string if your SQL Server configuration is different.

5. Open **Package Manager Console** and run:

```powershell
Update-Database
```

6. Run the application from Visual Studio.

The application starts on the sign-in page.
