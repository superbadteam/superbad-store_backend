using BuildingBlock.Core.Domain;
using SaleManagement.Core.Domain.ProductAggregate.Entities;

namespace SaleManagement.Core.Domain.CategoryAggregate.Entities;

public class Category : AggregateRoot
{
    public Category()
    {
        Products = new List<Product>();
        SubCategories = new List<Category>();
    }

    public Category(string name) : this()
    {
        Name = name;
    }

    public Category(string name, Guid parentId) : this(name)
    {
        ParentId = parentId;
    }

    public string Name { get; set; } = null!;

    public Guid? ParentId { get; set; }

    public ICollection<Product> Products { get; set; }

    public ICollection<Category> SubCategories { get; set; }

    public Category? Parent { get; set; }
}