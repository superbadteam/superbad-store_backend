using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace ShoppingManagement.Core.Application.Products.IntegrationEvents.Events;

public record OrderCreatedIntegrationEvent(IEnumerable<OrderItemPayload> Items, Guid UserId) : IntegrationEvent;

public class OrderItemPayload
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public double TotalPrice { get; set; }

    public Guid ProductTypeId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;
}