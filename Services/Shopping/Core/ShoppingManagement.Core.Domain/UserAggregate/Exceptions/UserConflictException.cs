using BuildingBlock.Core.Domain.Exceptions;
using ShoppingManagement.Core.Domain.UserAggregate.Entities;

namespace ShoppingManagement.Core.Domain.UserAggregate.Exceptions;

public class UserConflictException : EntityConflictException
{
    public UserConflictException(string column, string value) : base(nameof(User), column, value)
    {
    }

    public UserConflictException(Guid id) : base(nameof(User), id)
    {
    }
}