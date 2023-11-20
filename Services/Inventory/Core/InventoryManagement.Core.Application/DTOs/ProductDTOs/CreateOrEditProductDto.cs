using InventoryManagement.Core.Domain.ProductAggregate.Entities.Enums;

namespace InventoryManagement.Core.Application.DTOs.ProductDTOs;

public class CreateOrEditProductDto
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public int Quantity { get; set; }

    public double Price { get; set; }

    public ProductCondition Condition { get; set; }
}