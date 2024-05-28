# WebAppLogin API

## Description

WebAppLogin API is an authentication API that allows user registration, login, and obtaining a JWT token for authentication. It uses SQLite as the database and Entity Framework Core for data access.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQLite](https://www.sqlite.org/index.html)

## Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/yourusername/WebAppLogin.git
    cd WebAppLogin
    ```

2. Restore the NuGet packages:

    ```bash
    dotnet restore
    ```

3. Configure the connection string and JWT key in `appsettings.json`:

    ```json
    {
      "Jwt": {
        "Key": "YourSuperSecretKeyThatIsAtLeast32CharactersLong"
      },
      "ConnectionStrings": {
        "DefaultConnection": "Data Source=DataBase/users.db"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```

## Entity Framework Migrations

1. Add the initial migration:

    ```bash
    dotnet ef migrations add InitialCreate
    ```

2. Update the database:

    ```bash
    dotnet ef database update
    ```

## Running the Application

1. Run the application:

    ```bash
    dotnet run
    ```

2. The API will be available at `https://localhost:5001` or `http://localhost:5000`.

## Using the API

You can explore and test the API endpoints using Swagger. Once the application is running, navigate to `https://localhost:5001/swagger` or `http://localhost:5000/swagger` in your web browser.

## Contributions

Contributions are welcome. Please open an issue or submit a pull request for improvements and fixes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
