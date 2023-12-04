using BuildingBlock.Core.Domain;
using SaleManagement.Core.Domain.ProductAggregate.Entities;

namespace SaleManagement.Core.Domain.CategoryAggregate.Entities;

public sealed class Category : AggregateRoot
{
    public Category()
    {
        Products = new List<Product>();
        SubCategories = new List<Category>();
    }

    public Category(Guid id, string name, Guid? parentId, DateTime createdAt, string createdBy) : this()
    {
        Id = id;
        Name = name;
        ParentId = parentId;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }

    public string Name { get; set; } = null!;

    public Guid? ParentId { get; set; }

    public ICollection<Product> Products { get; set; }

    public ICollection<Category> SubCategories { get; set; }

    public Category? Parent { get; set; }
}