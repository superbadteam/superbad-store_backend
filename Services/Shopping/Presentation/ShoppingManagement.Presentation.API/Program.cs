using BuildingBlock.Core.Application.EventBus.Abstractions;
using BuildingBlock.Presentation.API.Extensions;
using BuildingBlock.Presentation.API.Hosts;
using BuildingBlock.Presentation.API.Middlewares;
using ShoppingManagement.Core.Application;
using ShoppingManagement.Core.Application.Categories.IntegrationEvents.Events;
using ShoppingManagement.Core.Application.Categories.IntegrationEvents.Handlers;
using ShoppingManagement.Core.Application.Products.IntegrationEvents.Events;
using ShoppingManagement.Core.Application.Products.IntegrationEvents.Handlers;
using ShoppingManagement.Core.Application.Users.IntegrationEvents.Events;
using ShoppingManagement.Core.Application.Users.IntegrationEvents.Handlers;
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

await app.UseDefaultMiddlewares(app.Environment, builder.Configuration);

app.MapControllers();

var eventBus = app.Services.GetRequiredService<IEventBus>();

eventBus.Subscribe<ProductCreatedIntegrationEvent, ProductCreatedIntegrationEventHandler>();
eventBus.Subscribe<ProductEditedIntegrationEvent, ProductEditedIntegrationEventHandler>();
eventBus.Subscribe<ProductDeletedIntegrationEvent, ProductDeletedIntegrationEventHandler>();

eventBus.Subscribe<UserCreatedIntegrationEvent, UserCreatedIntegrationEventHandler>();

eventBus.Subscribe<CategoryCreatedIntegrationEvent, CategoryCreatedIntegrationEventHandler>();

eventBus.Subscribe<OrderCreatedIntegrationEvent, OrderCreatedIntegrationEventHandler>();
eventBus.Subscribe<CartItemsRemovedIntegrationEvent, CartItemsRemovedIntegrationEventHandler>();
app.Run();