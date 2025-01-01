# Clean Architecture .NET Web API with CQRS and MediatR

## Overview
This project is a .NET 8 Web API designed using Clean Architecture principles, employing CQRS with MediatR for handling application logic, and Domain-Driven Design (DDD) to model the business domain.

### Key Features:
- Clean Architecture: Separation of concerns with distinct layers.
- CQRS (Command Query Responsibility Segregation): Differentiates between commands (write operations) and queries (read operations).
- MediatR: Simplifies handling requests with centralized mediation.
- Domain-Driven Design (DDD): Focus on the core domain and business logic.
- Testable and maintainable code.
- MSSQL as the database.

## Project Structure
The project is structured into the following libraries:

### 1. **Shared Library**
- **Shared**: Contains common utilities, helpers, and shared logic.
- **Shared.Abstraction**: Defines interfaces and abstractions used across the solution.

### 2. **CleanArchAndCQRS.Api**
- The entry point for client requests (Web API controllers).
- Configures routing, dependency injection, and middleware.
- Handles HTTP request/response lifecycle.

### 3. **CleanArchAndCQRS.Application**
- Implements CQRS using commands, queries, and handlers.
- Contains DTOs, validation logic, and business rules.
- Mediator patterns are implemented using MediatR.

### 4. **CleanArchAndCQRS.Domain**
- Contains the core business logic and domain models.
- Includes interfaces for repository abstractions.
- Implements value objects, entities, and domain events.

### 5. **CleanArchAndCQRS.Infrastructure**
- Handles external concerns such as database access, file systems, and third-party services.
- Implements repository patterns.
- Contains Entity Framework Core (EF Core) configurations.

## Getting Started

### Prerequisites
- [.NET 8](https://dotnet.microsoft.com/)
- [SQL Server](https://www.microsoft.com/sql-server)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or any compatible IDE

### Installation Steps
1. **Clone the Repository:**
   ```bash
   git clone https://github.com/mhaz2000/Clean-Architecture-and-CQRS-Template.git
   cd Clean-Architecture-and-CQRS-Template
   ```

2. **Restore NuGet Packages:**
   ```bash
   dotnet restore
   ```

3. **Set up the Database:**
   - Update the connection string in `appsettings.json` under the `CleanArchAndCQRS.Api` project.
   - Apply migrations:
     ```bash
     dotnet ef database update --project CleanArchAndCQRS.Infrastructure
     ```

4. **Run the Application:**
   ```bash
   dotnet run --project CleanArchAndCQRS.Api
   ```
   The API will be available at `https://localhost:5010`.

### Running Tests
- Unit tests are located in the `Tests` folder.
- Run all tests using the following command:
  ```bash
  dotnet test
  ```

## Usage

### Sample Endpoints
- **GET** `/api/packinglists`: Fetch a list of packingLists.
- **POST** `/api/packinglists`: Create a new packingLists.
- **PUT** `/api/packinglists/{id}`: Update an existing packingLists.
- **DELETE** `/api/packinglists/{id}`: Delete a packingLists.

## Additional Notes
- Follow the SOLID principles for extensibility and maintainability.
- Utilize domain events to propagate changes across the system.
- Use integration tests for validating end-to-end functionality.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

