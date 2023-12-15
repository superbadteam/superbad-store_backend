using BuildingBlock.Core.Domain.Exceptions;

namespace OrderManagement.Core.Domain.UserAggregate.Exceptions;

public class ShippingAddressNotFoundException : EntityNotFoundException
{
    public ShippingAddressNotFoundException(Guid shippingAddressId, Guid userId) : base(
        $"Shipping address with id: {shippingAddressId} was not found in user with id: {userId}")
    {
    }
}