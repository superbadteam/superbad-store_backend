using BuildingBlock.Core.Domain.Exceptions;
using InventoryManagement.Core.Domain.UserAggregate.Entities;

namespace InventoryManagement.Core.Domain.UserAggregate.Exceptions;

public class UserNotFoundException : EntityNotFoundException
{
    public UserNotFoundException(Guid id) : base(nameof(User), id)
    {
    }
}