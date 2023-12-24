using BuildingBlock.Core.Domain;
using SaleManagement.Core.Domain.ProductAggregate.Entities;

namespace SaleManagement.Core.Domain.UserAggregate.Entities;

public class Cart : Entity
{
    public Cart()
    {
    }

    public Cart(Guid productTypeId, double price, int quantity)
    {
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