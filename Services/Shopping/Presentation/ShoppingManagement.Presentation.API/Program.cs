using BuildingBlock.Presentation.API.Extensions;
using BuildingBlock.Presentation.API.Hosts;
using BuildingBlock.Presentation.API.Middlewares;
using ShoppingManagement.Core.Application;
using ShoppingManagement.Core.Domain;
using ShoppingManagement.Infrastructure.EntityFrameworkCore;
using ShoppingManagement.Presentation.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

await builder.Services
    .AddDefaultExtensions<ShoppingApplicationAssemblyReference, ShoppingDomainAssemblyReference, ShoppingDbContext>(
        builder.Configuration);

builder.Services.AddShoppingExtensions(builder.Configuration);

builder.Host.UseDefaultHosts(builder.Configuration);

var app = builder.Build();

await app.UseDefaultMiddlewares<ShoppingApplicationAssemblyReference>(app.Environment, builder.Configuration);

app.MapControllers();

app.Run();