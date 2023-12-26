using BuildingBlock.Core.Application.CQRS;
using ShoppingManagement.Core.Application.Users.DTOs;

namespace ShoppingManagement.Core.Application.Users.CQRS.Queries.Requests;

public record GetUserByIdQuery(Guid UserId) : IQuery<UserDto>;