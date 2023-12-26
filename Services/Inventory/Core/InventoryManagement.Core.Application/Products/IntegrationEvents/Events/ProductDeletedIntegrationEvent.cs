using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace InventoryManagement.Core.Application.Products.IntegrationEvents.Events;

public record ProductDeletedIntegrationEvent(Guid ProductId, DateTime? DeletedAt, string? DeletedBy) : IntegrationEvent;