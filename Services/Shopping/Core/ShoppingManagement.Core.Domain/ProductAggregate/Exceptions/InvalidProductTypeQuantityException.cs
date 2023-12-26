using BuildingBlock.Core.Domain.Exceptions;

namespace ShoppingManagement.Core.Domain.ProductAggregate.Exceptions;

public class InvalidProductTypeQuantityException : ValidationException
{
    public InvalidProductTypeQuantityException() : base("Quantity can not exceed the available stock.")
    {
    }
}