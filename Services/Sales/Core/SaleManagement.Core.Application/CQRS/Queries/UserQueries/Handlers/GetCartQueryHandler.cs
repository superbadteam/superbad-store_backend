using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using SaleManagement.Core.Application.CQRS.Queries.UserQueries.Requests;
using SaleManagement.Core.Application.DTOs.UserDTOs;
using SaleManagement.Core.Domain.UserAggregate.Entities;
using SaleManagement.Core.Domain.UserAggregate.Exceptions;
using SaleManagement.Core.Domain.UserAggregate.Specifications;

namespace SaleManagement.Core.Application.CQRS.Queries.UserQueries.Handlers;

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