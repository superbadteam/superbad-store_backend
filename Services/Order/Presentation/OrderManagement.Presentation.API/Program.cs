using BuildingBlock.Core.Application.EventBus.Abstractions;
using BuildingBlock.Presentation.API.Extensions;
using BuildingBlock.Presentation.API.Hosts;
using BuildingBlock.Presentation.API.Middlewares;
using OrderManagement.Core.Application;
using OrderManagement.Core.Application.IntegrationEvents.ProductIntegrationEvents.Events;
using OrderManagement.Core.Application.IntegrationEvents.ProductIntegrationEvents.Handlers;
using OrderManagement.Core.Application.IntegrationEvents.UserIntegrationEvents.Events;
using OrderManagement.Core.Application.IntegrationEvents.UserIntegrationEvents.Handlers;
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

await app.UseDefaultMiddlewares(app.Environment, builder.Configuration);

app.MapControllers();

var eventBus = app.Services.GetRequiredService<IEventBus>();

eventBus.Subscribe<ProductCreatedIntegrationEvent, ProductCreatedIntegrationEventHandler>();

eventBus.Subscribe<UserCreatedIntegrationEvent, UserCreatedIntegrationEventHandler>();
eventBus.Subscribe<CartItemAddedIntegrationEvent, CartItemAddedIntegrationEventHandler>();

app.Run();