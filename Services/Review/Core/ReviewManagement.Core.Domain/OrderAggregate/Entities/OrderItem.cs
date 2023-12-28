using BuildingBlock.Core.Domain;
using ReviewManagement.Core.Domain.ProductAggregate.Entities;
using ReviewManagement.Core.Domain.UserAggregate.Entities;

namespace ReviewManagement.Core.Domain.OrderAggregate.Entities;

public sealed class OrderItem : AggregateRoot
{
    public OrderItem()
    {
    }

    public OrderItem(Guid id, Guid productTypeId, Guid userId, int quantity, double totalPrice, DateTime createdAt,
        string createdBy)
    {
        Id = id;
        ProductTypeId = productTypeId;
        UserId = userId;
        Quantity = quantity;
        TotalPrice = totalPrice;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public Guid ProductTypeId { get; set; }

    public ProductType ProductType { get; set; } = null!;

    public int Quantity { get; set; }

    public double TotalPrice { get; set; }
}