using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using OrderManagement.Core.Domain.LocationAggregate.Entities;
using OrderManagement.Core.Domain.LocationAggregate.Exceptions;
using OrderManagement.Core.Domain.ProductAggregate.Entities;
using OrderManagement.Core.Domain.ProductAggregate.Exceptions;
using OrderManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;
using OrderManagement.Core.Domain.UserAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.Exceptions;
using OrderManagement.Core.Domain.UserAggregate.Specifications;
using OrderManagement.Core.Domain.UserAggregate.ValueObjects;

namespace OrderManagement.Core.Domain.UserAggregate.DomainServices.Implementations;

public class UserDomainService : IUserDomainService
{
    private readonly IReadOnlyRepository<Location> _locationReadOnlyRepository;
    private readonly IReadOnlyRepository<ProductType> _productTypeReadOnlyRepository;
    private readonly IReadOnlyRepository<ShippingAddress> _shippingAddressReadOnlyRepository;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public UserDomainService(IReadOnlyRepository<User> userReadOnlyRepository,
        IReadOnlyRepository<ProductType> productTypeReadOnlyRepository,
        IReadOnlyRepository<Location> locationReadOnlyRepository,
        IReadOnlyRepository<ShippingAddress> shippingAddressReadOnlyRepository)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _productTypeReadOnlyRepository = productTypeReadOnlyRepository;
        _locationReadOnlyRepository = locationReadOnlyRepository;
        _shippingAddressReadOnlyRepository = shippingAddressReadOnlyRepository;
    }

    public async Task<User> CreateAsync(Guid id, string name, DateTime createdAt, string createdBy)
    {
        await CheckValidOnCreateAsync(id);

        var user = new User(id, name, createdAt, createdBy);

        return user;
    }

    public async Task AddToCartAsync(User user, Guid cartItemId, Guid productTypeId, int quantity)
    {
        var cartItem = user.Carts.FirstOrDefault(item => item.Id == cartItemId);

        var productType = await CheckValidOnAddToCartAsync(cartItem, productTypeId, quantity);

        if (cartItem is not null)
        {
            cartItem.UpdateQuantity(quantity + cartItem.Quantity, productType.Price);

            user.UpdateTotalPrice();
        }
        else
        {
            user.AddToCart(cartItemId, productTypeId, productType.Price, quantity);
        }
    }

    public void RemoveFromCart(User user, Guid cartItemId)
    {
        var cartItem = user.Carts.FirstOrDefault(item => item.Id == cartItemId);

        if (cartItem is null) throw new CartItemNotFoundException(cartItemId, user.Id);

        user.RemoveFromCart(cartItem);
    }

    public async Task<ShippingAddress> CreateShippingAddressAsync(User user, string name, PhoneNumber phoneNumber,
        Guid districtId,
        string address, bool isMainAddress)
    {
        await CheckValidOnCreateShippingAddressAsync(districtId);

        var shippingAddress = new ShippingAddress(name, phoneNumber, districtId, address, isMainAddress);

        user.ShippingAddresses.Add(shippingAddress);

        return shippingAddress;
    }

    public async Task RemoveMainAddressStatusFromCurrentShippingAddressAsync(User user)
    {
        var shippingAddressIsMainAddressSpecification = new ShippingAddressIsMainAddressSpecification();

        var shippingAddress =
            await _shippingAddressReadOnlyRepository.GetAnyAsync(shippingAddressIsMainAddressSpecification);

        if (shippingAddress is null) return;

        shippingAddress.IsMainAddress = false;

        user.ShippingAddresses.Add(shippingAddress);
    }

    private async Task CheckValidOnCreateShippingAddressAsync(Guid districtId)
    {
        var location = await EntityHelper.GetOrThrowAsync(districtId, new DistrictNotFoundException(districtId),
            _locationReadOnlyRepository);

        if (location.ParentId is null) throw new InvalidDistrictException(districtId);
    }


    private async Task<ProductType> CheckValidOnAddToCartAsync(Cart? item, Guid productTypeId, int quantity)
    {
        var productType = await EntityHelper.GetOrThrowAsync(productTypeId,
            new ProductTypeNotFoundException(productTypeId), _productTypeReadOnlyRepository);

        if (item is null)
        {
            ThrowIfQuantityIsInvalid(productType, quantity);
        }
        else
        {
            if (item.ProductTypeId != productTypeId)
                throw new InvalidProductTypeInCartItemException(productTypeId, item.Id);
            ThrowIfQuantityIsInvalid(productType, quantity + item.Quantity);
        }

        return productType;
    }

    private static void ThrowIfQuantityIsInvalid(ProductType productType, int quantity)
    {
        if (productType.Quantity < quantity) throw new InvalidProductTypeQuantityException();
    }

    private async Task CheckValidOnCreateAsync(Guid id)
    {
        await ThrowIfExistAsync(id);
    }

    private async Task ThrowIfExistAsync(Guid id)
    {
        var userIdSpecification = new EntityIdSpecification<User>(id);

        Optional<bool>.Of(await _userReadOnlyRepository.CheckIfExistAsync(userIdSpecification))
            .ThrowIfExist(new UserConflictException(id));
    }
}