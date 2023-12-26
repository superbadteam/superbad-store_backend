using BuildingBlock.Core.Domain.Exceptions;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;

namespace ShoppingManagement.Core.Domain.ProductAggregate.Exceptions;

public class ProductNotFoundException : EntityNotFoundException
{
    public ProductNotFoundException(Guid id) : base(nameof(Product), id)
    {
    }
}