using BuildingBlock.Core.Application.CQRS;
using SaleManagement.Core.Application.DTOs.UserDTOs;

namespace SaleManagement.Core.Application.CQRS.Queries.UserQueries.Requests;

public record GetUserByIdQuery(Guid UserId) : IQuery<UserDto>;