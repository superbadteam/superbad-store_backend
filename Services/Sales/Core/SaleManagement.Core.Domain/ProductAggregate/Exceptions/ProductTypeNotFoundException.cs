using BuildingBlock.Core.Domain.Exceptions;
using SaleManagement.Core.Domain.ProductAggregate.Entities;

namespace SaleManagement.Core.Domain.ProductAggregate.Exceptions;

public class ProductTypeNotFoundException : EntityNotFoundException
{
    public ProductTypeNotFoundException(Guid id) : base(nameof(ProductType), id)
    {
    }

    public ProductTypeNotFoundException(Guid id, Guid productId) : base(
        $"Product type with id: {id} is not found in product with id: {productId}")
    {
    }
}