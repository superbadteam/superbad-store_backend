using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace OrderManagement.Core.Application.IntegrationEvents.UserIntegrationEvents.Events;

public record CartItemsRemovedIntegrationEvent(Guid UserId, IEnumerable<Guid> CartItemIds) : IntegrationEvent;