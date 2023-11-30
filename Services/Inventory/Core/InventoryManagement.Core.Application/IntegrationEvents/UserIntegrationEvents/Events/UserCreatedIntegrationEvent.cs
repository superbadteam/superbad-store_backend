using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace InventoryManagement.Core.Application.IntegrationEvents.UserIntegrationEvents.Events;

public record UserCreatedIntegrationEvent
(Guid UserId, string Name, DateTime CreatedAt,
    string CreatedBy) : EntityCreatedIntegrationEvent(CreatedAt, CreatedBy);