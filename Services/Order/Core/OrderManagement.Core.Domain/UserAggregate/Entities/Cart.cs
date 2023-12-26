using BuildingBlock.Core.Domain;
using OrderManagement.Core.Domain.ProductAggregate.Entities;

namespace OrderManagement.Core.Domain.UserAggregate.Entities;

public sealed class Cart : Entity
{
    public Cart()
    {
    }

    public Cart(Guid id, Guid productTypeId, double price, int quantity)
    {
        Id = id;
        ProductTypeId = productTypeId;
        Quantity = quantity;
        TotalPrice = price * quantity;
    }

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public Guid ProductTypeId { get; set; }

    public ProductType ProductType { get; set; } = null!;

    public int Quantity { get; set; }

    public double TotalPrice { get; set; }

    public void UpdateQuantity(int quantity, double price)
    {
        Quantity = quantity;
        TotalPrice = price * quantity;
    }
}