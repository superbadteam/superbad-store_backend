using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace InventoryManagement.Core.Application.Products.IntegrationEvents.Events;

public record OrderCreatedIntegrationEvent(IEnumerable<OrderItemPayload> Items, Guid UserId) : IntegrationEvent;

public class OrderItemPayload
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public Guid ProductTypeId { get; set; }
}