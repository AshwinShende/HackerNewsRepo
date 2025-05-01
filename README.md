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

# FrontEnd Angular

This is an Angular application that displays the latest stories from a news API. The project is designed with a responsive layout, featuring a left navigation menu and a top menu bar. It also includes a loader component to indicate loading states.

## Features

- **Left Navigation Menu**: Navigate between different sections of the application.
- **Top Menu Bar**: Displays the application title.
- **Loader Component**: Displays a loading spinner while fetching data.
- **API Integration**: Fetches the newest stories from a backend API.
- **Responsive Design**: Built with Angular Material and Bootstrap for a modern UI.

## Prerequisites

- [Node.js](https://nodejs.org/) (v16 or higher recommended)
- [Angular CLI](https://angular.io/cli) (v15 or higher)

## Installation

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd Hacker-News-Feed/story-feed-app
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

3. Start the development server:
   ```bash
   ng serve
   ```

4. Open the application in your browser:
   ```
   http://localhost:4200
   ```

## Project Structure

```
story-feed-app/
├── src/
│   ├── app/
│   │   ├── components/
│   │   │   ├── loader/
│   │   │   │   ├── loader.component.html
│   │   │   │   ├── loader.component.ts
│   │   │   │   ├── loader.component.scss
│   │   ├── services/
│   │   │   ├── story-feed-service.ts
│   │   ├── navigation/
│   │   │   ├── navigation.component.html
│   │   │   ├── navigation.component.ts
│   │   │   ├── navigation.component.scss
│   ├── styles.css
├── angular.json
├── package.json
```

## Key Components

### Loader Component
- **File**: `loader.component.html`
- **Description**: Displays a spinner when the `loading$` observable emits `true`.
- **Code**:
  ```html
  <div *ngIf="loaderService.loading$ | async" class="spinner-border text-primary" role="status">
    <span class="visually-hidden">Loading...</span>
  </div>
  ```

### Story Feed Service
- **File**: `story-feed-service.ts`
- **Description**: Fetches the newest stories from the backend API.
- **Code**:
  ```typescript
  getNewestStories(): Observable<any[]> {
    return this.http.get<any[]>(this.API_URL);
  }
  ```

## Dependencies

- **Angular**: Framework for building the application.
- **Angular Material**: Provides UI components like navigation and toolbar.
- **Bootstrap**: Adds responsive design and styling.
- **RxJS**: Handles asynchronous data streams.

## API Configuration

The API URL is defined in the `StoryFeedService`:
```typescript
private API_URL = 'https://localhost:44306/api/news';
```
Ensure the backend API is running and accessible at this URL.

## Running Tests

To run unit tests:
```bash
ng test
```

## Build for Production

To build the application for production:
```bash
ng build --configuration production
```

   
   
