using BuildingBlock.Core.Domain;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;

namespace InventoryManagement.Core.Domain.CategoryAggregate.Entities;

public class Category : AggregateRoot
{
    public string Name { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = null!;
}