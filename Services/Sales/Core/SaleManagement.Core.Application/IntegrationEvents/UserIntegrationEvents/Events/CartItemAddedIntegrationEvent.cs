using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace SaleManagement.Core.Application.IntegrationEvents.UserIntegrationEvents.Events;

public record CartItemAddedIntegrationEvent
    (Guid UserId, Guid CartItemId, Guid ProductTypeId, int Quantity) : IntegrationEvent;