using BuildingBlock.Core.Domain.Exceptions;
using ReviewManagement.Core.Domain.ProductAggregate.Entities;

namespace ReviewManagement.Core.Domain.ProductAggregate.Exceptions;

public class ProductNotFoundException : EntityNotFoundException
{
    public ProductNotFoundException(Guid id) : base(nameof(Product), id)
    {
    }
}