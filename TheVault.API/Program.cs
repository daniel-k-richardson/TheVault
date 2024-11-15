using TheVault.Domain.Boxes.Entities;
using TheVault.Persistence;
using TheVault.Persistence.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistence(builder.Configuration.GetConnectionString("DefaultConnection"));

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

app.MapGet("/api/boxes", (AppDataContext context) =>
    {
        var box = new Box("Box 1", "Living Room", "A box in the living room");
        box.AddItem(new Item("Item 1", "A thing"));
        box.AddItem(new Item("Item 2", "Another thing"));
        context.Boxes.Add(box);
        context.SaveChanges();

        var results = context.Boxes.ToList();

        return Results.Ok(results);

    })
    .WithName("GetBoxes");

app.MapGet("/api/boxes/add-item", (AppDataContext context) =>
    {
        var box = context.Boxes.First();

        return Results.Ok(box);

    })
    .WithName("GetBox");

app.Run();

