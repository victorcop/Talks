# 🎤 Talks API

A clean architecture ASP.NET Core Web API for managing conference talks and presentations.

## 📖 Overview

This project demonstrates a well-structured .NET 9.0 solution following clean architecture principles with separation of concerns across multiple layers:

- **API Layer**: RESTful endpoints using ASP.NET Core 🌐
- **Service Layer**: Business logic and data transformation ⚙️
- **Domain Layer**: Core business entities and models 📦

## ✨ Features

- 🔌 RESTful API for retrieving conference talks
- 🏗️ Clean architecture with dependency injection
- 🗺️ AutoMapper for object-to-object mapping
- 📚 Swagger/OpenAPI documentation
- 📋 DTO pattern for API responses

## 📁 Project Structure

```
Talks.sln
├── Talks.Api/              # Web API layer
│   ├── Controllers/        # API endpoints
│   ├── Program.cs          # Application entry point
│   └── appsettings.json    # Configuration
├── Talks.Service/          # Business logic layer
│   ├── TalkService.cs      # Service implementation
│   ├── ITalkService.cs     # Service interface
│   ├── Models/             # DTOs
│   ├── Mapper/             # AutoMapper profiles
│   └── Extension/          # Service registration extensions
├── Talks.Domain/           # Domain models
│   └── Talk.cs             # Talk entity
└── Talks.Tests/            # Unit tests
    ├── Services/           # Service layer tests
    └── Controllers/        # Controller tests
```

## ⚡ Prerequisites

- .NET 9.0 SDK or later
- Visual Studio 2022 or VS Code
- (Optional) Postman or similar tool for API testing

## 🚀 Getting Started

### 💻 Installation Instructions - Visual Studio

1. Clone or download the repository
2. Open `Talks.sln` in Visual Studio 2022
3. Restore NuGet packages (automatic on build)
4. Set `Talks.Api` as the startup project
5. Build and run the solution (F5)

### ⌨️ Installation Instructions - Command Line

```bash
# Navigate to the solution directory
cd Talks

# Restore dependencies
dotnet restore

# Build the solution
dotnet build

# Run the API
dotnet run --project Talks.Api
```

## 🔗 API Endpoints

### 📋 Get All Talks

```http
GET /api/talks
```

**Response:**
- `200 OK`: Returns a list of talks
- `204 No Content`: No talks available

**Example Response:**
```json
[
  {
    "talkId": 1,
    "title": "Introduction to Clean Architecture",
    "abstract": "Learn the principles of clean architecture..."
  }
]
```

## 📖 Swagger Documentation

When running in Development mode, Swagger UI is available at:
```
https://localhost:{port}/swagger
```

This provides interactive API documentation and testing capabilities.

## 🛠️ Technologies Used

- **ASP.NET Core 9.0**: Web API framework
- **AutoMapper**: Object-to-object mapping
- # 🧪 Testing

- **xUnit**: Testing framework
- **Moq**: Mocking library
- **FluentAssertions**: Assertion library for readable tests

##**Swashbuckle**: Swagger/OpenAPI documentation
- **Dependency Injection**: Built-in DI container

## 🏛️ Architecture

The project follows clean architecture principles:

1. **Talks.Domain**: Contains core business entities with no external dependencies
2. **Talks.Service**: Implements business logic, depends on Domain layer
3. **Talks.Api**: Handles HTTP requests/responses, depends on Service layer

This� Running Tests

### Run all tests
```bash
dotnet test
```

### Run tests with detailed output
```bash
dotnet test --verbosity detailed
```

### Run tests with code coverage
```bash
dotnet test /p:CollectCoverage=true
```

### Test Coverage

The test suite includes:
- **TalkService Tests**: Unit tests for business logic
  - Validates data retrieval and mapping
  - Tests empty result scenarios
  - Verifies repository interactions
- **TalksController Tests**: Unit tests for API endpoints
  - Tests successful responses (200 OK)
  - Tests empty responses (204 No Content)
  - Validates service method calls
  - Theory tests for multiple scenarios

## � separation ensures:
- ✅ Testability
- 🔧 Maintainability
- 🎯 Clear separation of concerns
- 🔄 Flexibility to change implementations

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## 📄 License

This project is for educational/demonstration purposes.
