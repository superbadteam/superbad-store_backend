using BuildingBlock.Core.Application.CQRS;
using OrderManagement.Core.Application.Users.DTOs;

namespace OrderManagement.Core.Application.Users.CQRS.Queries.Requests;

public sealed record GetUserDistributionQuery : IQuery<List<LocationUserCountDto>>;