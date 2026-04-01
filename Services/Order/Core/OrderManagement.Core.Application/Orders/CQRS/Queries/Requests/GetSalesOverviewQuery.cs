using BuildingBlock.Core.Application.CQRS;
using OrderManagement.Core.Application.Orders.DTOs;

namespace OrderManagement.Core.Application.Orders.CQRS.Queries.Requests;

public sealed record GetSalesOverviewQuery : IQuery<SalesOverviewResponse>;