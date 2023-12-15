using BuildingBlock.Core.Domain;
using OrderManagement.Core.Domain.ProductAggregate.Entities;

namespace OrderManagement.Core.Domain.OrderAggregate.Entities;

public class OrderItem : Entity
{
    public OrderItem()
    {
    }

    public OrderItem(Guid productTypeId, int quantity, double totalPrice)
    {
        ProductTypeId = productTypeId;
        Quantity = quantity;
        TotalPrice = totalPrice;
    }

    public Guid OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public Guid ProductTypeId { get; set; }

    public ProductType ProductType { get; set; } = null!;

    public int Quantity { get; set; }

    public double TotalPrice { get; set; }
}