using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using ReviewManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;
using ReviewManagement.Core.Domain.UserAggregate.Entities;
using ReviewManagement.Core.Domain.UserAggregate.Exceptions;

namespace ReviewManagement.Core.Domain.UserAggregate.DomainServices.Implementations;

public class UserDomainService : IUserDomainService
{
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public UserDomainService(IReadOnlyRepository<User> userReadOnlyRepository)

    {
        _userReadOnlyRepository = userReadOnlyRepository;
    }

    public async Task<User> CreateAsync(Guid id, string name, string? avatarUrl, DateTime createdAt, string createdBy)
    {
        await CheckValidOnCreateAsync(id);

        var user = new User(id, name, avatarUrl, createdAt, createdBy);

        return user;
    }

    public void Delete(User user, DateTime? deletedAt, string? deletedBy)
    {
        user.Delete(deletedAt, deletedBy);
    }

    private async Task CheckValidOnCreateAsync(Guid id)
    {
        await EntityHelper.ThrowIfExistAsync(id, new UserConflictException(id), _userReadOnlyRepository);
    }
}