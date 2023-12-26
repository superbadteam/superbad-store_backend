namespace InventoryManagement.Core.Application.Products.ProductDTOs;

public class DeleteManyProductsDto
{
    public IEnumerable<Guid> Ids { get; set; } = null!;
}