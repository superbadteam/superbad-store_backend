using BuildingBlock.Core.Application.EventBus.Abstractions;
using BuildingBlock.Presentation.API.Extensions;
using BuildingBlock.Presentation.API.Hosts;
using BuildingBlock.Presentation.API.Middlewares;
using InventoryManagement.Core.Application;
using InventoryManagement.Core.Application.IntegrationEvents.ProductIntegrationEvents.Events;
using InventoryManagement.Core.Application.IntegrationEvents.ProductIntegrationEvents.Handlers;
using InventoryManagement.Core.Domain;
using InventoryManagement.Infrastructure.EntityFrameworkCore;
using InventoryManagement.Presentation.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

await builder.Services
    .AddDefaultExtensions<InventoryApplicationAssemblyReference, InventoryDomainAssemblyReference, InventoryDbContext>(
        builder.Configuration);

builder.Services.AddInventoryExtensions(builder.Configuration);

builder.Host.UseDefaultHosts(builder.Configuration);

var app = builder.Build();

await app.UseDefaultMiddlewares(app.Environment, builder.Configuration);

app.MapControllers();

var eventBus = app.Services.GetRequiredService<IEventBus>();

eventBus.Subscribe<OrderCreatedIntegrationEvent, OrderCreatedIntegrationEventHandler>();

app.Run();