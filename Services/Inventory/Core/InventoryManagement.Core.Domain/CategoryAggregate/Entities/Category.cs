using BuildingBlock.Core.Domain;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;

namespace InventoryManagement.Core.Domain.CategoryAggregate.Entities;

public class Category : AggregateRoot
{
    public Category()
    {
    }

    public Category(string name)
    {
        Name = name;
    }

    public Category(string name, Guid parentId)
    {
        Name = name;
        ParentId = parentId;
    }

    public string Name { get; set; } = null!;

    public Guid? ParentId { get; set; }
    public ICollection<Product> Products { get; set; } = null!;
}