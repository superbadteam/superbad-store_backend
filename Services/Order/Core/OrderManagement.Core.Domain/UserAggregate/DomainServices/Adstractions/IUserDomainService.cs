using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;

public interface IUserDomainService
{
    Task<User> CreateAsync(Guid id, string name, DateTime dateTime, string createdBy);
}