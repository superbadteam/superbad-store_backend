using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace OrderManagement.Core.Application.Users.IntegrationEvents.Events;

public record UserRestoredIntegrationEvent(Guid UserId) : IntegrationEvent;