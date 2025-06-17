# fintech-app-simulator

This repository contains a sample fintech microservice solution. The first service implemented is **AccountService** which exposes a simple REST API for account management.

## Structure

```
src/
  AccountService/
    AccountService.Domain/        - Domain entities and interfaces
    AccountService.Application/   - Application layer logic
    AccountService.Infrastructure/ - EF Core database context and repository
    AccountService.API/           - ASP.NET Core minimal API
    Dockerfile                    - Container image definition

tests/
  AccountService.Tests/           - xUnit tests
```

## Building

```
# Build the solution
dotnet build

# Run tests
dotnet test
```

The API can be executed locally using `dotnet run` from `src/AccountService/AccountService.API`. A default connection string named `DefaultConnection` is required in `appsettings.json`.
