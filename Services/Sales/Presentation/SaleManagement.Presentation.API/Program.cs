using BuildingBlock.Core.Application.EventBus.Abstractions;
using BuildingBlock.Presentation.API.Extensions;
using BuildingBlock.Presentation.API.Hosts;
using BuildingBlock.Presentation.API.Middlewares;
using SaleManagement.Core.Application;
using SaleManagement.Core.Application.IntegrationEvents.CategoryIntegrationEvents.Events;
using SaleManagement.Core.Application.IntegrationEvents.CategoryIntegrationEvents.Handlers;
using SaleManagement.Core.Application.IntegrationEvents.ProductIntegrationEvents.Events;
using SaleManagement.Core.Application.IntegrationEvents.ProductIntegrationEvents.Handlers;
using SaleManagement.Core.Application.IntegrationEvents.UserIntegrationEvents.Events;
using SaleManagement.Core.Application.IntegrationEvents.UserIntegrationEvents.Handlers;
using SaleManagement.Core.Domain;
using SaleManagement.Infrastructure.EntityFrameworkCore;
using SaleManagement.Presentation.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

await builder.Services
    .AddDefaultExtensions<SaleApplicationAssemblyReference, SaleDomainAssemblyReference, SaleDbContext>(
        builder.Configuration);

builder.Services.AddSaleExtensions(builder.Configuration);

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

app.Run();