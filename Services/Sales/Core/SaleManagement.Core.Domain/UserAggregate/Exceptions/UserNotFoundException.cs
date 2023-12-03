using BuildingBlock.Core.Domain.Exceptions;
using SaleManagement.Core.Domain.UserAggregate.Entities;

namespace SaleManagement.Core.Domain.UserAggregate.Exceptions;

public class UserNotFoundException : EntityNotFoundException
{
    public UserNotFoundException(Guid id) : base(nameof(User), id)
    {
    }
}