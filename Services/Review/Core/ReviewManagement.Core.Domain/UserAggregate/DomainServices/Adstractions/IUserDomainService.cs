using ReviewManagement.Core.Domain.UserAggregate.Entities;

namespace ReviewManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;

public interface IUserDomainService
{
    Task<User> CreateAsync(Guid id, string name, string? avatarUrl, DateTime dateTime, string createdBy);

    void Delete(User user, DateTime? deletedAt, string? deletedBy);
}