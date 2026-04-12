using MediatR;
using Microsoft.EntityFrameworkCore;
using repositoryStore.Application;
using repositoryStore.Infrastructure;
using repositoryStore.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

var cnnStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not found");
builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseNpgsql(cnnStr, b => b.MigrationsAssembly("repositoryStore.Infrastructure")));

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("v1/products/{id:int}", async (ISender sender, int id, CancellationToken cancellationToken) =>
{
    var command = new repositoryStore.Application.UseCases.Products.GetById.Command(id);
    var result = await sender.Send(command, cancellationToken);
    return result.IsSuccess
        ? Results.Ok(result.Value)
        : Results.BadRequest(result.Error);
});

app.MapPost("v1/products", async (ISender sender, repositoryStore.Application.UseCases.Products.Create.Command command, CancellationToken cancellationToken) =>
{
    var result = await sender.Send(command, cancellationToken);
    return result.IsSuccess
        ? Results.Ok(result.Value)
        : Results.BadRequest(result.Error);
});

app.Run();