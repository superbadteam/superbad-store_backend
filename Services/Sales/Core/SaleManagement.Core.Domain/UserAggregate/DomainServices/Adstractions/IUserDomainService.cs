using SaleManagement.Core.Domain.UserAggregate.Entities;

namespace SaleManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;

public interface IUserDomainService
{
    Task<User> CreateAsync(Guid id, string name, DateTime dateTime, string createdBy);
}