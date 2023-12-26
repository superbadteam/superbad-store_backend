using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Core.Domain.UserAggregate.Exceptions;

public class InvalidProductTypeInCartItemException : ValidationException
{
    public InvalidProductTypeInCartItemException(Guid productTypeId, Guid cartItemId)
        : base(
            $"Product type with id: {productTypeId} is not match with product type in cart item with id: {cartItemId}")
    {
    }
}