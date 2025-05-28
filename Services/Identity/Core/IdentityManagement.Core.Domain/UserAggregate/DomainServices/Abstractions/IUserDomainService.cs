using IdentityManagement.Core.Domain.UserAggregate.Entities;

namespace IdentityManagement.Core.Domain.UserAggregate.DomainServices.Abstractions;

public interface IUserDomainService
{
    void AddRefreshToken(User user, string refreshToken);

    Task<User> CreateAsync(string email, string name, string password, string confirmPassword, string id);

    Task<string> ResetPasswordAsync(User user, string password, string confirmPassword);

    Task DeleteAsync(User user);
}