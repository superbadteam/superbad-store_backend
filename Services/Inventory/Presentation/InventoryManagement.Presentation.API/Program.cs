using BuildingBlock.Presentation.API.Extensions;
using BuildingBlock.Presentation.API.Hosts;
using BuildingBlock.Presentation.API.Middlewares;
using InventoryManagement.Core.Application;
using InventoryManagement.Core.Domain;
using InventoryManagement.Infrastructure.EntityFrameworkCore;
using InventoryManagement.Presentation.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

await builder.Services
    .AddDefaultExtensions<ProductApplicationAssemblyReference, ProductDomainAssemblyReference, InventoryDbContext>(
        builder.Configuration);

builder.Services.AddProductExtensions(builder.Configuration);

builder.Host.UseDefaultHosts(builder.Configuration);

var app = builder.Build();

await app.UseDefaultMiddlewares(app.Environment, builder.Configuration);

app.MapControllers();

app.Run();