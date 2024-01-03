using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace OrderManagement.Core.Application.Users.IntegrationEvents.Events;

public record UserDeletedIntegrationEvent(Guid UserId, DateTime? DeletedAt, string? DeletedBy) : IntegrationEvent;