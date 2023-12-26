using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace SaleManagement.Core.Application.IntegrationEvents.UserIntegrationEvents.Events;

public record CartItemsRemovedIntegrationEvent(Guid UserId, IEnumerable<Guid> CartItemIds) : IntegrationEvent;