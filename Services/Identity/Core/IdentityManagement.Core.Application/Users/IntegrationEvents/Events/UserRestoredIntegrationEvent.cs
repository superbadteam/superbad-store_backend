using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace IdentityManagement.Core.Application.Users.IntegrationEvents.Events;

public record UserRestoredIntegrationEvent(Guid UserId) : IntegrationEvent;