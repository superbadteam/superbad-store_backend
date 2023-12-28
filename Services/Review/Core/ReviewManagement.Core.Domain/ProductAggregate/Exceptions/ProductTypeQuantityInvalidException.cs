using BuildingBlock.Core.Domain.Exceptions;

namespace ReviewManagement.Core.Domain.ProductAggregate.Exceptions;

public class ProductTypeQuantityInvalidException : ValidationException
{
    public ProductTypeQuantityInvalidException() : base("Quantity can not exceed the available stock.")
    {
    }
}