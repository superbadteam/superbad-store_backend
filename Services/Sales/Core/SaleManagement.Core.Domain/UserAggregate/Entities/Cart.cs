using BuildingBlock.Core.Domain;
using SaleManagement.Core.Domain.ProductAggregate.Entities;

namespace SaleManagement.Core.Domain.UserAggregate.Entities;

public class Cart : Entity
{
    public Cart()
    {
    }

    public Cart(ProductType productType, int quantity)
    {
        ProductType = productType;
        Quantity = quantity;
        TotalPrice = productType.Price * quantity;
    }

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public Guid ProductTypeId { get; set; }

    public ProductType ProductType { get; set; } = null!;

    public int Quantity { get; set; }

    public double TotalPrice { get; set; }
}