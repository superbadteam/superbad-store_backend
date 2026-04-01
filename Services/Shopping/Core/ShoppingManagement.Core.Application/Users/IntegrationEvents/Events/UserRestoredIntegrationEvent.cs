using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace ShoppingManagement.Core.Application.Users.IntegrationEvents.Events;

public record UserRestoredIntegrationEvent(Guid UserId) : IntegrationEvent;