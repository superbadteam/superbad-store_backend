using BuildingBlock.Core.Domain.Exceptions;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Core.Domain.UserAggregate.Exceptions;

public class UserNotFoundException : EntityNotFoundException
{
    public UserNotFoundException(Guid id) : base(nameof(User), id)
    {
    }
}