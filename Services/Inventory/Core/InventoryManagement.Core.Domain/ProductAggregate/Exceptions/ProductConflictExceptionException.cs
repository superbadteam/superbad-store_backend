using BuildingBlock.Core.Domain.Exceptions;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;

namespace InventoryManagement.Core.Domain.ProductAggregate.Exceptions;

public class ProductConflictExceptionException : EntityConflictException
{
    public ProductConflictExceptionException(string column, string value) : base(nameof(Product), column, value)
    {
    }
}