using BuildingBlock.Core.Domain.Exceptions;
using SaleManagement.Core.Domain.ProductAggregate.Entities;

namespace SaleManagement.Core.Domain.ProductAggregate.Exceptions;

public class ProductConflictException : EntityConflictException
{
    public ProductConflictException(string column, string value) : base(nameof(Product), column, value)
    {
    }

    public ProductConflictException(Guid id) : base(nameof(Product), id)
    {
    }
}