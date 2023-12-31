using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.DTOs;
using BuildingBlock.Core.Domain.Repositories;
using ReviewManagement.Core.Application.Orders.CQRS.Queries.Events;
using ReviewManagement.Core.Application.Orders.DTOs;
using ReviewManagement.Core.Domain.OrderAggregate.Entities;
using ReviewManagement.Core.Domain.OrderAggregate.Specifications;

namespace ReviewManagement.Core.Application.Orders.CQRS.Queries.Handlers;

public class FilterAndPagingCurrentUserReviewableOrderItemsHandler : IQueryHandler<
    FilterAndPagingCurrentUserReviewableOrderItemsQuery, FilterAndPagingResultDto<OrderItemDto>>
{
    private readonly ICurrentUser _currentUser;
    private readonly IReadOnlyRepository<OrderItem> _orderItemReadOnlyRepository;

    public FilterAndPagingCurrentUserReviewableOrderItemsHandler(
        IReadOnlyRepository<OrderItem> orderItemReadOnlyRepository,
        ICurrentUser currentUser)
    {
        _orderItemReadOnlyRepository = orderItemReadOnlyRepository;
        _currentUser = currentUser;
    }

    public async Task<FilterAndPagingResultDto<OrderItemDto>> Handle(
        FilterAndPagingCurrentUserReviewableOrderItemsQuery request,
        CancellationToken cancellationToken)
    {
        var orderItemUserIdSpecification = new OrderItemUserIdSpecification(_currentUser.Id);
        var orderItemReviewableSpecification = new OrderItemReviewableSpecification();

        var specification = orderItemReviewableSpecification.And(orderItemUserIdSpecification);

        var (orderItems, totalCount) = await _orderItemReadOnlyRepository.GetFilterAndPagingAsync<OrderItemDto>(
            specification, request.Dto.Sort,
            request.Dto.PageIndex, request.Dto.PageSize);

        return new FilterAndPagingResultDto<OrderItemDto>(orderItems, request.Dto.PageIndex, request.Dto.PageSize,
            totalCount);
    }
}