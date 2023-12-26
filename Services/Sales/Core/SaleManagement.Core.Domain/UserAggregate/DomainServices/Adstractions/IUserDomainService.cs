using SaleManagement.Core.Domain.UserAggregate.Entities;

namespace SaleManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;

public interface IUserDomainService
{
    Task<User> CreateAsync(Guid id, string name, DateTime dateTime, string createdBy);

    Task<Cart> AddToCartAsync(User user, Guid productTypeId, int quantity);

    void RemoveFromCart(User user, Guid cartItemId);
}