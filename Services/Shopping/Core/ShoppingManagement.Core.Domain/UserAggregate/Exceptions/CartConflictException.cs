using BuildingBlock.Core.Domain.Exceptions;

namespace ShoppingManagement.Core.Domain.UserAggregate.Exceptions;

public class CartConflictException : EntityConflictException
{
    public CartConflictException(Guid productId) : base($"Product with id: {productId} is already in cart.")
    {
    }
}