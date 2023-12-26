using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace SaleManagement.Core.Application.Products.IntegrationEvents.Events;

public record ProductDeletedIntegrationEvent(Guid ProductId, DateTime? DeletedAt, string? DeletedBy) : IntegrationEvent;