using BuildingBlock.Core.Domain.Exceptions;
using ReviewManagement.Core.Domain.ProductAggregate.Entities;

namespace ReviewManagement.Core.Domain.ProductAggregate.Exceptions;

public class ProductTypeNotFoundException : EntityNotFoundException
{
    public ProductTypeNotFoundException(Guid id) : base(nameof(ProductType), id)
    {
    }
}