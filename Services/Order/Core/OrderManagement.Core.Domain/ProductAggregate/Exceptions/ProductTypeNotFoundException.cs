using BuildingBlock.Core.Domain.Exceptions;
using OrderManagement.Core.Domain.ProductAggregate.Entities;

namespace OrderManagement.Core.Domain.ProductAggregate.Exceptions;

public class ProductTypeNotFoundException : EntityNotFoundException
{
    public ProductTypeNotFoundException(Guid id) : base(nameof(ProductType), id)
    {
    }
}