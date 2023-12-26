using BuildingBlock.Core.Application.CQRS;
using SaleManagement.Core.Application.Users.DTOs;

namespace SaleManagement.Core.Application.Users.CQRS.Queries.Requests;

public record GetUserByIdQuery(Guid UserId) : IQuery<UserDto>;