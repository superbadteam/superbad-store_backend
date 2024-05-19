using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.DTOs;
using ReviewManagement.Core.Application.Orders.DTOs;

namespace ReviewManagement.Core.Application.Orders.CQRS.Queries.Events;

public record FilterAndPagingCurrentUserReviewableOrderItemsQuery(FilterAndPagingCurrentUserReviewableOrderItemsDto Dto)
    : IQuery<FilterAndPagingResultDto<OrderItemDto>>;