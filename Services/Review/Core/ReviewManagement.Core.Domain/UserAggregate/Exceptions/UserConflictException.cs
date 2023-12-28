using BuildingBlock.Core.Domain.Exceptions;
using ReviewManagement.Core.Domain.UserAggregate.Entities;

namespace ReviewManagement.Core.Domain.UserAggregate.Exceptions;

public class UserConflictException : EntityConflictException
{
    public UserConflictException(string column, string value) : base(nameof(User), column, value)
    {
    }

    public UserConflictException(Guid id) : base(nameof(User), id)
    {
    }
}