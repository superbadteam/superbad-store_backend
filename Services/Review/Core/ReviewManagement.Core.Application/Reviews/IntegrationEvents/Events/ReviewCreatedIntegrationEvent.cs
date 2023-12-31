using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace ReviewManagement.Core.Application.Reviews.IntegrationEvents.Events;

public record ReviewCreatedIntegrationEvent(Guid ProductId, int Rating) : IntegrationEvent;