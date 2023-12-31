namespace IdentityManagement.Core.Domain.PermissionAggregate.Repositories;

public interface IPermissionReadOnlyRepository
{
    Task<IEnumerable<string>> GetNamesByRoleNameAsync(string roleName);
}