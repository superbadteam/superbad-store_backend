using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using SaleManagement.Core.Application.CQRS.Queries.UserQueries.Requests;
using SaleManagement.Core.Application.DTOs.UserDTOs;
using SaleManagement.Core.Domain.UserAggregate.Entities;
using SaleManagement.Core.Domain.UserAggregate.Exceptions;

namespace SaleManagement.Core.Application.CQRS.Queries.UserQueries.Handlers;

public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto>
{
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public GetUserByIdQueryHandler(IReadOnlyRepository<User> userReadOnlyRepository)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var specification = new EntityIdSpecification<User>(request.UserId);

        return Optional<UserDto>.Of(await _userReadOnlyRepository.GetAnyAsync<UserDto>(specification))
            .ThrowIfNotExist(new UserNotFoundException(request.UserId)).Get();
    }
}