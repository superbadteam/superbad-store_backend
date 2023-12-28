using BuildingBlock.Core.Domain.Exceptions;

namespace ReviewManagement.Core.Domain.OrderAggregate.Exceptions;

public class OrderItemNotFoundException : EntityNotFoundException
{
    public OrderItemNotFoundException(Guid orderItemId, Guid userId) : base(
        $"User with id: {userId} has no order item with id: {orderItemId}")
    {
    }
}