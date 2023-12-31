using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace OrderManagement.Core.Application.Users.IntegrationEvents.Events;

public record CartItemsRemovedIntegrationEvent(Guid UserId, IEnumerable<Guid> CartItemIds) : IntegrationEvent;