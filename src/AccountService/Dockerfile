# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ./AccountService.Domain/ ./AccountService.Domain/
COPY ./AccountService.Application/ ./AccountService.Application/
COPY ./AccountService.Infrastructure/ ./AccountService.Infrastructure/
COPY ./AccountService.API/ ./AccountService.API/
RUN dotnet publish AccountService.API/ -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AccountService.API.dll"]
