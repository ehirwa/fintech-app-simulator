using AccountService.Application;
using AccountService.Domain;
using AccountService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddDbContext<AccountDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<AccountService.Application.AccountService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AccountService", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/accounts/user/{userId}", async (Guid userId, AccountService.Application.AccountService service) =>
{
    var accounts = await service.GetByUserAsync(userId);
    return Results.Ok(accounts);
});

app.MapGet("/accounts/{id}", async (Guid id, AccountService.Application.AccountService service) =>
{
    var account = await service.GetByIdAsync(id);
    return account is null ? Results.NotFound() : Results.Ok(account);
});

app.MapPost("/accounts", async (Guid userId, Currency currency, AccountService.Application.AccountService service) =>
{
    var account = await service.CreateAsync(userId, currency);
    return Results.Created($"/accounts/{account.Id}", account);
});

app.MapDelete("/accounts/{id}", async (Guid id, AccountService.Application.AccountService service) =>
{
    var account = await service.GetByIdAsync(id);
    if (account is null) return Results.NotFound();
    await service.DeleteAsync(account);
    return Results.NoContent();
});

app.Run();
