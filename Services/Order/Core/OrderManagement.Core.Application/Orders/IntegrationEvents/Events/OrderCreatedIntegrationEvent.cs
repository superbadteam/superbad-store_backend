using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace OrderManagement.Core.Application.Orders.IntegrationEvents.Events;

public record OrderCreatedIntegrationEvent(IEnumerable<OrderItemPayload> Items) : IntegrationEvent;

public class OrderItemPayload
{
    public int Quantity { get; set; }

    public Guid ProductTypeId { get; set; }
}