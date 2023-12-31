using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using ReviewManagement.Core.Domain.OrderAggregate.Entities;

namespace ReviewManagement.Core.Domain.OrderAggregate.Specifications;

public class OrderItemReviewableSpecification : Specification<OrderItem>
{
    public override Expression<Func<OrderItem, bool>> ToExpression()
    {
        return orderItem =>
            orderItem.User.Reviews.All(review => review.ProductType.ProductId != orderItem.ProductType.ProductId);
    }
}