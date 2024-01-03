using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace ReviewManagement.Core.Application.Users.IntegrationEvents.Events;

public record UserDeletedIntegrationEvent(Guid UserId, DateTime? DeletedAt, string? DeletedBy) : IntegrationEvent;