using ShoppingManagement.Core.Domain.UserAggregate.Entities;

namespace ShoppingManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;

public interface IUserDomainService
{
    Task<User> CreateAsync(Guid id, string name, string? avatarUrl, string? coverUrl, DateTime dateTime,
        string createdBy);

    Task<Cart> AddToCartAsync(User user, Guid productTypeId, int quantity);

    void RemoveFromCart(User user, Guid cartItemId);

    void Delete(User user, DateTime? deletedAt, string? deletedBy);
}