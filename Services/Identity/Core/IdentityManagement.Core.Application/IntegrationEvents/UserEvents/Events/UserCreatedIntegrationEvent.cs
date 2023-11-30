using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace IdentityManagement.Core.Application.IntegrationEvents.UserEvents.Events;

public record UserCreatedIntegrationEvent
(Guid UserId, string Name, DateTime CreatedAt,
    string CreatedBy) : EntityCreatedIntegrationEvent(CreatedAt, CreatedBy);