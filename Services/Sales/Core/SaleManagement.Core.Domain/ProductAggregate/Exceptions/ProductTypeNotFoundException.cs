using BuildingBlock.Core.Domain.Exceptions;
using SaleManagement.Core.Domain.ProductAggregate.Entities;

namespace SaleManagement.Core.Domain.ProductAggregate.Exceptions;

public class ProductTypeNotFoundException : EntityNotFoundException
{
    public ProductTypeNotFoundException(Guid id) : base(nameof(ProductType), id)
    {
    }
}