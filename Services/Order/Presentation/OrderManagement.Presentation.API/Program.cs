using BuildingBlock.Presentation.API.Extensions;
using BuildingBlock.Presentation.API.Hosts;
using BuildingBlock.Presentation.API.Middlewares;
using OrderManagement.Core.Application;
using OrderManagement.Core.Domain;
using OrderManagement.Infrastructure.EntityFrameworkCore;
using OrderManagement.Presentation.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

await builder.Services
    .AddDefaultExtensions<OrderApplicationAssemblyReference, OrderDomainAssemblyReference, OrderDbContext>(
        builder.Configuration);

builder.Services.AddOrderExtensions(builder.Configuration);

builder.Host.UseDefaultHosts(builder.Configuration);

var app = builder.Build();

await app.UseDefaultMiddlewares<OrderApplicationAssemblyReference>(app.Environment, builder.Configuration);

app.MapControllers();

app.Run();