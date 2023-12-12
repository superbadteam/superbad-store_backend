using BuildingBlock.Core.Domain.Exceptions;
using OrderManagement.Core.Domain.ProductAggregate.Entities;

namespace OrderManagement.Core.Domain.ProductAggregate.Exceptions;

public class ProductConflictException : EntityConflictException
{
    public ProductConflictException(string column, string value) : base(nameof(Product), column, value)
    {
    }

    public ProductConflictException(Guid id) : base(nameof(Product), id)
    {
    }
}