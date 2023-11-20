using InventoryManagement.Core.Domain.ProductAggregate.Entities.Enums;

namespace InventoryManagement.Core.Application.DTOs.ProductDTOs;

public class ProductDetailDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public ProductCondition Condition { get; set; }
}