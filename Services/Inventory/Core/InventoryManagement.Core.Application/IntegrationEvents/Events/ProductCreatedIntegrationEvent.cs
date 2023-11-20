using BuildingBlock.Core.Application.IntegrationEvents.Events;
using InventoryManagement.Core.Domain.ProductAggregate.Entities.Enums;

namespace InventoryManagement.Core.Application.IntegrationEvents.Events;

public record ProductCreatedIntegrationEvent(Guid ProductId, string ProductCode, string ProductName,
    double ProductPrice, bool ProductIsAvailable, ProductCondition ProductCondition, DateTime CreatedAt,
    string CreatedBy) : IntegrationEvent;