using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace SaleManagement.Core.Application.Users.IntegrationEvents.Events;

public record UserCreatedIntegrationEvent
(Guid UserId, string Name, DateTime CreatedAt,
    string CreatedBy) : EntityCreatedIntegrationEvent(CreatedAt, CreatedBy);