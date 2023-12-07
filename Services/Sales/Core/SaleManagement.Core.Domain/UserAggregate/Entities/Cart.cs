using BuildingBlock.Core.Domain;
using SaleManagement.Core.Domain.ProductAggregate.Entities;

namespace SaleManagement.Core.Domain.UserAggregate.Entities;

public class Cart : Entity
{
    public Guid UserId { get; set; }
    
    public User User { get; set; } = null!;
    
    public Guid ProductId { get; set; }
    
    public Product Product { get; set; } = null!;
    
    public int Quantity { get; set; }
    
    public double TotalPrice { get; set; }
}