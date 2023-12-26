using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using SaleManagement.Core.Application.Users.CQRS.Queries.Requests;
using SaleManagement.Core.Application.Users.DTOs;
using SaleManagement.Core.Domain.UserAggregate.Entities;
using SaleManagement.Core.Domain.UserAggregate.Exceptions;

namespace SaleManagement.Core.Application.Users.CQRS.Queries.Handlers;

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