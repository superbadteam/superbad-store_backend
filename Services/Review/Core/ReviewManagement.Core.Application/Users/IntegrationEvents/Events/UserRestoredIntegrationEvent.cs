using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace ReviewManagement.Core.Application.Users.IntegrationEvents.Events;

public record UserRestoredIntegrationEvent(Guid UserId) : IntegrationEvent;