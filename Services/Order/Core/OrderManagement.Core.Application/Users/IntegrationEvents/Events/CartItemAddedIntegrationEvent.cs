using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace OrderManagement.Core.Application.Users.IntegrationEvents.Events;

public record CartItemAddedIntegrationEvent(Guid UserId, Guid CartItemId, Guid ProductTypeId, int Quantity)
    : IntegrationEvent;