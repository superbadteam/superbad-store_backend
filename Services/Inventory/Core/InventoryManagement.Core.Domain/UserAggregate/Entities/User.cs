using BuildingBlock.Core.Domain;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;

namespace InventoryManagement.Core.Domain.UserAggregate.Entities;

public class User : AggregateRoot
{
    public string Name { get; set; } = null!;

    public double AverageRating { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int ProductSold { get; set; }

    public ICollection<Product> Products { get; set; } = null!;
}