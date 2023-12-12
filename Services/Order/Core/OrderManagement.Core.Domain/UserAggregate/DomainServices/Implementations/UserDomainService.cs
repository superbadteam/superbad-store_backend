using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using OrderManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;
using OrderManagement.Core.Domain.UserAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.Exceptions;

namespace OrderManagement.Core.Domain.UserAggregate.DomainServices.Implementations;

public class UserDomainService : IUserDomainService
{
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public UserDomainService(IReadOnlyRepository<User> userReadOnlyRepository)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
    }

    public async Task<User> CreateAsync(Guid id, string name, DateTime createdAt, string createdBy)
    {
        await CheckValidOnCreateAsync(id);

        var user = new User(id, name, createdAt, createdBy);

        return user;
    }

    private async Task CheckValidOnCreateAsync(Guid id)
    {
        await ThrowIfExistAsync(id);
    }

    private async Task ThrowIfExistAsync(Guid id)
    {
        var userIdSpecification = new EntityIdSpecification<User>(id);

        Optional<bool>.Of(await _userReadOnlyRepository.CheckIfExistAsync(userIdSpecification))
            .ThrowIfExist(new UserConflictException(id));
    }
}