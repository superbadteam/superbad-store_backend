using BuildingBlock.Core.Domain.Exceptions;

namespace IdentityManagement.Core.Domain.RoleAggregate.Exceptions;

public class UserRoleConflictException : EntityConflictException
{
    public UserRoleConflictException(Guid roleId, Guid userId) : base(
        $"User with id: '{userId}' already has role with id: '{roleId}'")
    {
    }
}