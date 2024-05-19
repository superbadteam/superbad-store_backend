using BuildingBlock.Core.Application.IntegrationEvents.Events;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;

namespace ShoppingManagement.Core.Application.Products.IntegrationEvents.Events;

public record ProductEditedIntegrationEvent(
    Guid ProductId,
    string ProductCode,
    string ProductName,
    double ProductPrice,
    bool ProductIsAvailable,
    ProductType ProductType,
    DateTime? UpdatedAt,
    string? UpdatedBy) : IntegrationEvent;