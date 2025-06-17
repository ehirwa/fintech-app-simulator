# fintech-app-simulator

This repository contains a simplified core banking simulation built in a modular way. Services are added gradually following Clean Architecture principles.

## AccountService

The first module provides a basic account management REST API implemented with **.NET 7** and **Entity Framework Core** targeting SQL Server. It exposes CRUD endpoints for accounts in multiple currencies (USD, EUR, RWF).

### Running locally

Docker is used for local development. Build and start the API together with a SQL Server instance:

```bash
docker-compose up --build
```

The API will be available on `http://localhost:5000` with Swagger UI at `/swagger`.

### Project structure

- `AccountService/src` – service implementation following Clean Architecture
- `AccountService/tests` – xUnit tests

More services (KYC, Transactions, etc.) will be added in future iterations.
