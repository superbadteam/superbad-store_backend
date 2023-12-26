using BuildingBlock.Core.Domain.Exceptions;

namespace ShoppingManagement.Core.Domain.UserAggregate.Exceptions;

public class CartItemNotFoundException : EntityNotFoundException
{
    public CartItemNotFoundException(Guid cartItemId, Guid userId) : base(
        $"Cart item with id: {cartItemId} was not found in user with id: {userId}.")
    {
    }
}