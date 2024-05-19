using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace OrderManagement.Core.Application.Users.IntegrationEvents.Events;

public record UserCreatedIntegrationEvent(
    Guid UserId,
    string Name,
    string? AvatarUrl,
    string? CoverUrl,
    DateTime CreatedAt,
    string CreatedBy) : EntityCreatedIntegrationEvent(CreatedAt, CreatedBy);