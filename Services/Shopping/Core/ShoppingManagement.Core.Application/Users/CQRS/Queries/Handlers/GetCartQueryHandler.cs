using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using ShoppingManagement.Core.Application.Users.CQRS.Queries.Requests;
using ShoppingManagement.Core.Application.Users.DTOs;
using ShoppingManagement.Core.Domain.UserAggregate.Entities;
using ShoppingManagement.Core.Domain.UserAggregate.Exceptions;
using ShoppingManagement.Core.Domain.UserAggregate.Specifications;

namespace ShoppingManagement.Core.Application.Users.CQRS.Queries.Handlers;

public class GetCartQueryHandler : IQueryHandler<GetCartQuery, CartDto>
{
    private readonly ICurrentUser _currentUser;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public GetCartQueryHandler(IReadOnlyRepository<User> userReadOnlyRepository, ICurrentUser currentUser)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _currentUser = currentUser;
    }

    public async Task<CartDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var specification = new UserIdSpecification(_currentUser.Id);

        return Optional<CartDto>.Of(await _userReadOnlyRepository.GetAnyAsync<CartDto>(specification))
            .ThrowIfNotExist(new UserNotFoundException(_currentUser.Id)).Get();
    }
}