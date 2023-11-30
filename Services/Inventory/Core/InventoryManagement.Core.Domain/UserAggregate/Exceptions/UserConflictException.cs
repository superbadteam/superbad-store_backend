using BuildingBlock.Core.Domain.Exceptions;
using InventoryManagement.Core.Domain.UserAggregate.Entities;

namespace InventoryManagement.Core.Domain.UserAggregate.Exceptions;

public class UserConflictException : EntityConflictException
{
    public UserConflictException(string column, string value) : base(nameof(User), column, value)
    {
    }

    public UserConflictException(Guid id) : base(nameof(User), id)
    {
    }
}