using InventoryManagement.Core.Domain.ProductAggregate.Entities.Enums;

namespace InventoryManagement.Core.Application.Products.ProductDTOs;

public class CreateOrEditProductDto
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public IEnumerable<CreateProductTypeDto> Types { get; set; } = null!;

    public IEnumerable<CreateProductImageDto> Images { get; set; } = null!;

    public ProductCondition Condition { get; set; }
}