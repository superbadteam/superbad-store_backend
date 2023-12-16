using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace InventoryManagement.Core.Application.IntegrationEvents.ProductIntegrationEvents.Events;

public record ProductDeletedIntegrationEvent(Guid ProductId, DateTime? DeletedAt, string? DeletedBy) : IntegrationEvent;