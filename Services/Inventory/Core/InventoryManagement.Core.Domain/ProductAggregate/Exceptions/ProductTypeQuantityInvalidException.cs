using BuildingBlock.Core.Domain.Exceptions;

namespace InventoryManagement.Core.Domain.ProductAggregate.Exceptions;

public class ProductTypeQuantityInvalidException : ValidationException
{
    public ProductTypeQuantityInvalidException() : base("Quantity can not exceed the available stock.")
    {
    }
}