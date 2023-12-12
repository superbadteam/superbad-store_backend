using BuildingBlock.Core.Domain.Exceptions;
using OrderManagement.Core.Domain.ProductAggregate.Entities;

namespace OrderManagement.Core.Domain.ProductAggregate.Exceptions;

public class ProductNotFoundException : EntityNotFoundException
{
    public ProductNotFoundException(Guid id) : base(nameof(Product), id)
    {
    }
}