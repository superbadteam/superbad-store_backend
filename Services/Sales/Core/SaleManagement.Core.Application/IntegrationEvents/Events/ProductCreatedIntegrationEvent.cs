using BuildingBlock.Core.Application.IntegrationEvents.Events;
using SaleManagement.Core.Domain.ProductAggregate.Entities;

namespace SaleManagement.Core.Application.IntegrationEvents.Events;

public record ProductCreatedIntegrationEvent(Guid ProductId, string ProductCode, string ProductName,
    double ProductPrice, bool ProductIsAvailable, ProductType ProductType, DateTime CreatedAt,
    string CreatedBy) : IntegrationEvent;