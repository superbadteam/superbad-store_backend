using BuildingBlock.Core.Domain.Exceptions;

namespace OrderManagement.Core.Domain.OrderAggregate.Exceptions;

public class OrderItemConflictException : EntityConflictException
{
    public OrderItemConflictException(Guid id) : base($"item with id: {id} already exists in order")
    {
    }
}