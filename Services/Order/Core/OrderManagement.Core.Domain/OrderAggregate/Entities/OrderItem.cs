using BuildingBlock.Core.Domain;
using OrderManagement.Core.Domain.ProductAggregate.Entities;

namespace OrderManagement.Core.Domain.OrderAggregate.Entities;

public class OrderItem : Entity
{
    public Guid OrderId { get; set; }

    public Order Order { get; set; } = null!;
    
    public Guid ProductTypeId { get; set; }
    
    public ProductType ProductType { get; set; } = null!;
    
    public int Quantity { get; set; }
    
    public double TotalPrice { get; set; }
}