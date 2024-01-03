using OrderManagement.Core.Domain.UserAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.ValueObjects;

namespace OrderManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;

public interface IUserDomainService
{
    Task<User> CreateAsync(Guid id, string name, DateTime dateTime, string createdBy);

    Task AddToCartAsync(User user, Guid cartItemId, Guid productTypeId, int quantity);

    void RemoveFromCart(User user, Guid cartItemId);

    Task<ShippingAddress> CreateShippingAddressAsync(User user, string name, PhoneNumber phoneNumber, Guid districtId,
        string address,
        bool isMainAddress);

    Task RemoveMainAddressStatusFromCurrentShippingAddressAsync(User user);

    void Delete(User user, DateTime? deletedAt, string? deletedBy);
}