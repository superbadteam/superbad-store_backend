using BuildingBlock.Core.Application.CQRS;
using ReviewManagement.Core.Application.Orders.DTOs;

namespace ReviewManagement.Core.Application.Orders.CQRS.Query.Events;

public record GetCurrentUserReviewableOrderItemsAsync : IQuery<List<OrderItemDto>>;