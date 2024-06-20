# Authentication and Authorization with Blazor

This project demonstrates how to implement authentication and authorization in a Blazor application. It includes a .NET Core Web API for user management and JWT token-based authentication.

## Features

- User registration and login
- JWT token generation and validation
- Role-based authorization
- Secure API endpoints

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2019 or later](https://visualstudio.microsoft.com/) with ASP.NET and web development workload
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-editions-express)

### Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/Ibraheem-MuhammedAmeen/Authentication-and-Authorization-With-Blazor.git
    cd Authentication-and-Authorization-With-Blazor
    ```

2. **Set up the database:**

    - Update the connection string in `appsettings.json` to point to your SQL Server instance.
    - Apply migrations to create the database schema.

    ```bash
    dotnet ef database update
    ```

3. **Run the application:**

    ```bash
    dotnet run
    ```

    The API will be available at `https://localhost:5001`.

## Project Structure

- **Server:** Contains the ASP.NET Core Web API for user management and JWT token generation.
- **Client:** Contains the Blazor WebAssembly application for user registration, login, and authorization.

## API Endpoints

- `POST /api/accounts/create`: Register a new user
- `POST /api/accounts/login`: Authenticate a user and return a JWT token
- `GET /api/protected`: A protected endpoint accessible only to authenticated users

## Usage

1. **Register a new user:**

    Send a `POST` request to `/api/accounts/create` with the following JSON payload:

    ```json
    {
        "email": "user@example.com",
        "password": "P@ssword123"
    }
    ```

2. **Login:**

    Send a `POST` request to `/api/accounts/login` with the following JSON payload:

    ```json
    {
        "email": "user@example.com",
        "password": "P@ssword123"
    }
    ```

    You will receive a JWT token in the response.

3. **Access protected endpoints:**

    Include the JWT token in the `Authorization` header of your requests:

    ```http
    Authorization: Bearer your-jwt-token
    ```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

