# REST-API-SWAGGER

This project is a sample REST API built using C# and ASP.NET Core. It includes Swagger for API documentation.

## Project Description

This project demonstrates how to set up a REST API using ASP.NET Core and integrate Swagger for API documentation. It includes basic CRUD operations and demonstrates good practices in API development.

## Features

- **REST API**: Implements basic CRUD operations.
- **Swagger Integration**: Provides interactive API documentation using Swagger UI.
- **Dependency Injection**: Uses Scoped services for dependency injection.

## Setup and Usage

### Prerequisites

- .NET 6.0 SDK or later
- Visual Studio or Visual Studio Code

### Getting Started

1. **Clone the repository**:
   ```sh
   git clone https://github.com/panuponzx/REST-API-SWAGGER.git
   cd REST-API-SWAGGER
2. **Build the project**:
   ```sh
   dotnet build
3. **Run the project**:
   ```sh
   dotnet run
4. **Access Swagger UI**:
    Open your browser and navigate to https://localhost:5001/swagger to view the interactive API documentation.

# Project Structure
  - Program.cs: Configures the application, including setting up Swagger and dependency injection.
  - Controllers: Contains the API controllers that handle HTTP requests.
