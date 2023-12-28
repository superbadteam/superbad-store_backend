using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using ReviewManagement.Core.Domain.OrderAggregate.Entities;

namespace ReviewManagement.Core.Domain.OrderAggregate.Specifications;

public class OrderItemUserIdSpecification : Specification<OrderItem>
{
    private readonly Guid _userId;

    public OrderItemUserIdSpecification(Guid userId)
    {
        _userId = userId;
    }

    public override Expression<Func<OrderItem, bool>> ToExpression()
    {
        return orderItem => orderItem.UserId == _userId;
    }
}