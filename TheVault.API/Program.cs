using TheVault.API.Configure;
using TheVault.API.Interfaces;
using TheVault.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistence(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Register all IEndpoints implementations
builder.Services.AddEndpoints();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Register all endpoints
var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoints>>();
foreach (var endpoint in endpoints)
{
    endpoint.DefineEndpoint(app);
}

app.Run();

