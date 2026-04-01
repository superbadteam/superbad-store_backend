using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace OrderManagement.Core.Application.Products.IntegrationEvents.Events;

public sealed record ProductEditedIntegrationEvent(
    Guid ProductId, int Quantity) : IntegrationEvent;