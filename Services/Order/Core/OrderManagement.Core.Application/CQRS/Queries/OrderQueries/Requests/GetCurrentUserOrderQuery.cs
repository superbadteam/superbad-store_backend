using BuildingBlock.Core.Application.CQRS;
using OrderManagement.Core.Application.DTOs.OrderDTOs;

namespace OrderManagement.Core.Application.CQRS.Queries.OrderQueries.Requests;

public record GetCurrentUserOrderQuery(Guid Id) : IQuery<OrderDetailDto>;