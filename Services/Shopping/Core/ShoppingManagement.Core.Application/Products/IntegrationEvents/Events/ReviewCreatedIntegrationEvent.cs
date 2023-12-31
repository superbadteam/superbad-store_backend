using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace ShoppingManagement.Core.Application.Products.IntegrationEvents.Events;

public record ReviewCreatedIntegrationEvent(Guid ProductId, int Rating) : IntegrationEvent;