using BuildingBlock.Core.Domain.Exceptions;
using OrderManagement.Core.Domain.OrderAggregate.Entities;

namespace OrderManagement.Core.Domain.OrderAggregate.Exceptions;

public class OrderNotFoundException : EntityNotFoundException
{
    public OrderNotFoundException(Guid id) : base(nameof(Order), id)
    {
    }
}