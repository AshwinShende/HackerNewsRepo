# NewsAPI Backend

The **NewsAPI Backend** is a .NET 8-based web API designed to manage and serve news stories. It is built with a modular architecture, including separate layers for data access, service logic, and shared utilities.

## Features
- RESTful API for managing news stories.
- Modular architecture with separate layers:
  - **Backend**: API controllers and entry point.
  - **Service Layer**: Business logic and service interfaces.
  - **Data Access Layer**: Database interactions.
  - **Shared**: Common utilities and models.
- Integrated Swagger for API documentation.
- Docker support for containerized deployment.

## Technologies Used
- **.NET 8**
- **Swashbuckle.AspNetCore** for Swagger documentation.
- **Dependency Injection** for service and data layer integration.
- **xUnit** and **Moq** for unit testing.
- **Docker** for containerization.


## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/) (optional, for containerized deployment)

### Setup Instructions
1. Clone the repository:git clone https://github.com/HackerNewsRepo/NewsAPI-Backend.git cd NewsAPI-Backend
2. Restore dependencies:dotnet restore
3. Build the solution:dotnet build
4. Run the application: dotnet run --project NewsAPI-Backend


5. Access the API documentation:
   Open your browser and navigate to `http://localhost:<port>/swagger`.

### Running Tests
To run the unit tests:
dotnet test


## Configuration
The application uses `appsettings.json` and `appsettings.Development.json` for configuration. Update these files to configure database connections, logging, and other settings.

## Docker Support
To build and run the application in a Docker container:
1. Build the Docker image:
   docker build -t newsapi-backend .
2. Run the container:
   docker run -p 8080:80 newsapi-backend

   
3. Access the API at `http://localhost:8080`.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

   
   
