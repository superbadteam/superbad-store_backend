using BuildingBlock.Core.Application.IntegrationEvents.Events;
using InventoryManagement.Core.Domain.ProductAggregate.Entities.Enums;

namespace InventoryManagement.Core.Application.Products.IntegrationEvents.Events;

public sealed record ProductEditedIntegrationEvent(
    Guid ProductId, int Quantity) : IntegrationEvent;