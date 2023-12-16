using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using OrderManagement.Core.Domain.OrderAggregate.Entities;

namespace OrderManagement.Core.Domain.OrderAggregate.Specifications;

public class OrderUserIdSpecification : Specification<Order>
{
    private readonly Guid _userId;

    public OrderUserIdSpecification(Guid userId)
    {
        _userId = userId;
    }

    public override Expression<Func<Order, bool>> ToExpression()
    {
        return order => order.UserId == _userId;
    }
}