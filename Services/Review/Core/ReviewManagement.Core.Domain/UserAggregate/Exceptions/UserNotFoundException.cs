using BuildingBlock.Core.Domain.Exceptions;
using ReviewManagement.Core.Domain.UserAggregate.Entities;

namespace ReviewManagement.Core.Domain.UserAggregate.Exceptions;

public class UserNotFoundException : EntityNotFoundException
{
    public UserNotFoundException(Guid id) : base(nameof(User), id)
    {
    }
}