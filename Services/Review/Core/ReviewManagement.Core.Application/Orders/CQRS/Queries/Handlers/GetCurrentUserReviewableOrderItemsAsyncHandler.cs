using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using ReviewManagement.Core.Application.Orders.CQRS.Query.Events;
using ReviewManagement.Core.Application.Orders.DTOs;
using ReviewManagement.Core.Domain.OrderAggregate.Entities;
using ReviewManagement.Core.Domain.OrderAggregate.Specifications;

namespace ReviewManagement.Core.Application.Orders.CQRS.Queries.Handlers;

public class
    GetCurrentUserReviewableOrderItemsAsyncHandler : IQueryHandler<GetCurrentUserReviewableOrderItemsAsync,
        List<OrderItemDto>>
{
    private readonly ICurrentUser _currentUser;
    private readonly IReadOnlyRepository<OrderItem> _orderItemReadOnlyRepository;

    public GetCurrentUserReviewableOrderItemsAsyncHandler(IReadOnlyRepository<OrderItem> orderItemReadOnlyRepository,
        ICurrentUser currentUser)
    {
        _orderItemReadOnlyRepository = orderItemReadOnlyRepository;
        _currentUser = currentUser;
    }

    public Task<List<OrderItemDto>> Handle(GetCurrentUserReviewableOrderItemsAsync request,
        CancellationToken cancellationToken)
    {
        var orderItemUserIdSpecification = new OrderItemUserIdSpecification(_currentUser.Id);
        var orderItemReviewableSpecification = new OrderItemReviewableSpecification();

        var specification = orderItemReviewableSpecification.And(orderItemUserIdSpecification);

        return _orderItemReadOnlyRepository.GetAllAsync<OrderItemDto>(specification);
    }
}