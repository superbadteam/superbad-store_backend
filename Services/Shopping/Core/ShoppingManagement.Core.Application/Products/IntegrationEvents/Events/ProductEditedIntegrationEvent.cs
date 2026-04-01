using BuildingBlock.Core.Application.IntegrationEvents.Events;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;

namespace ShoppingManagement.Core.Application.Products.IntegrationEvents.Events;

public sealed record ProductEditedIntegrationEvent(
    Guid ProductId, int Quantity) : IntegrationEvent;