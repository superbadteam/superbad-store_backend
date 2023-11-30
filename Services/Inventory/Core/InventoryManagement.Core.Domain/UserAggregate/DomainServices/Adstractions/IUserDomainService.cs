using InventoryManagement.Core.Domain.UserAggregate.Entities;

namespace InventoryManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;

public interface IUserDomainService
{
    Task<User> CreateAsync(Guid id, string name, DateTime dateTime, string createdBy);
}