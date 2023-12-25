using BuildingBlock.Core.Domain.Exceptions;

namespace OrderManagement.Core.Domain.ProductAggregate.Exceptions;

public class InvalidProductTypeQuantityException : ValidationException
{
    public InvalidProductTypeQuantityException() : base("Quantity can not exceed the available stock.")
    {
    }
}