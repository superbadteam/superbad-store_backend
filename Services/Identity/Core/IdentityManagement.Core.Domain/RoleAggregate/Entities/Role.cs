using BuildingBlock.Core.Domain;
using IdentityManagement.Core.Domain.PermissionAggregate.Entities;

namespace IdentityManagement.Core.Domain.RoleAggregate.Entities;

public class Role : Entity
{
    public Role(string roleName)
    {
        Name = roleName;
    }

    public Role()
    {
    }

    public string Name { get; set; } = null!;

    public string ConcurrencyStamp { get; set; } = null!;

    public List<UserRole> UserRoles { get; set; } = new();

    public List<Permission> Permissions { get; set; } = new();
}