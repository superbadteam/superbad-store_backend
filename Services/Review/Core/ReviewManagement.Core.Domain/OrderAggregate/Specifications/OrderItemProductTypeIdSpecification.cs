using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using ReviewManagement.Core.Domain.OrderAggregate.Entities;

namespace ReviewManagement.Core.Domain.OrderAggregate.Specifications;

public class OrderItemProductTypeIdSpecification : Specification<OrderItem>
{
    private readonly Guid _productTypeId;

    public OrderItemProductTypeIdSpecification(Guid productTypeId)
    {
        _productTypeId = productTypeId;
    }

    public override Expression<Func<OrderItem, bool>> ToExpression()
    {
        return orderItem => orderItem.ProductTypeId == _productTypeId;
    }
}