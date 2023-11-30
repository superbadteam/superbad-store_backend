using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using InventoryManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;
using InventoryManagement.Core.Domain.UserAggregate.Entities;
using InventoryManagement.Core.Domain.UserAggregate.Exceptions;
using InventoryManagement.Core.Domain.UserAggregate.Specifications;

namespace InventoryManagement.Core.Domain.UserAggregate.DomainServices.Implementations;

public class UserDomainService : IUserDomainService
{
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public UserDomainService(IReadOnlyRepository<User> userReadOnlyRepository)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
    }

    public async Task<User> CreateAsync(Guid id, string name, DateTime createdAt, string createdBy)
    {
        await CheckValidOnCreate(id);

        var user = new User(id, name, createdAt, createdBy);

        return user;
    }

    private async Task CheckValidOnCreate(Guid id)
    {
        await ThrowIfExist(id);
    }

    private async Task ThrowIfExist(Guid id)
    {
        var userIdSpecification = new UserIdSpecification(id);

        Optional<bool>.Of(await _userReadOnlyRepository.CheckIfExistAsync(userIdSpecification))
            .ThrowIfExist(new UserConflictException(id));
    }
}