using BuildingBlock.Core.Application.IntegrationEvents.Events;
using InventoryManagement.Core.Domain.ProductAggregate.Entities.Enums;

namespace InventoryManagement.Core.Application.Products.IntegrationEvents.Events;

public record ProductEditedIntegrationEvent(
    Guid ProductId,
    string ProductCode,
    string ProductName,
    double ProductPrice,
    bool ProductIsAvailable,
    ProductCondition ProductCondition,
    DateTime? UpdatedAt,
    string? UpdatedBy) : IntegrationEvent;