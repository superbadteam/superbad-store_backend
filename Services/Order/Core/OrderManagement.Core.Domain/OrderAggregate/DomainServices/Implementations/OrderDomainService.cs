using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using OrderManagement.Core.Domain.OrderAggregate.DomainEvents.Events;
using OrderManagement.Core.Domain.OrderAggregate.DomainServices.Abstractions;
using OrderManagement.Core.Domain.OrderAggregate.Entities;
using OrderManagement.Core.Domain.OrderAggregate.Exceptions;
using OrderManagement.Core.Domain.OrderAggregate.Specifications;
using OrderManagement.Core.Domain.ProductAggregate.Entities;
using OrderManagement.Core.Domain.ProductAggregate.Exceptions;
using OrderManagement.Core.Domain.UserAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.Exceptions;
using OrderManagement.Core.Domain.UserAggregate.Specifications;

namespace OrderManagement.Core.Domain.OrderAggregate.DomainServices.Implementations;

public class OrderDomainService : IOrderDomainService
{
    private readonly IReadOnlyRepository<Cart> _cartReadOnlyRepository;
    private readonly IReadOnlyRepository<ProductType> _productTypeReadOnlyRepository;
    private readonly IReadOnlyRepository<ShippingAddress> _shippingAddressReadOnlyRepository;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public OrderDomainService(IReadOnlyRepository<ProductType> productTypeReadOnlyRepository,
        IReadOnlyRepository<User> userReadOnlyRepository,
        IReadOnlyRepository<ShippingAddress> shippingAddressReadOnlyRepository,
        IReadOnlyRepository<Cart> cartReadOnlyRepository)
    {
        _productTypeReadOnlyRepository = productTypeReadOnlyRepository;
        _userReadOnlyRepository = userReadOnlyRepository;
        _shippingAddressReadOnlyRepository = shippingAddressReadOnlyRepository;
        _cartReadOnlyRepository = cartReadOnlyRepository;
    }

    public async Task<OrderItem> CreateItemAsync(Guid productTypeId, int quantity)
    {
        var productType = await CheckValidOnCreateItemAsync(productTypeId, quantity);

        return new OrderItem(productTypeId, quantity, productType.Price * quantity);
    }

    public async Task<OrderItem> CreateItemAsync(Guid userId, Guid cartItemId)
    {
        var cartItem = await CheckValidOnCreateItemAsync(userId, cartItemId);

        return new OrderItem(cartItem.ProductTypeId, cartItem.Quantity, cartItem.TotalPrice);
    }

    public async Task<Order> CreateAsync(Guid userId, Guid shippingAddressId, List<OrderItem> orderItems,
        IEnumerable<Guid>? cartItemIds)
    {
        await CheckValidOnCreateAsync(userId, shippingAddressId, orderItems);

        var order = new Order(userId, shippingAddressId, orderItems);

        order.AddDomainEvent(new OrderItemCreatedDomainEvent(orderItems, cartItemIds, userId));

        return order;
    }

    private async Task<ProductType> CheckValidOnCreateItemAsync(Guid productTypeId, int quantity)
    {
        var productType = await EntityHelper.GetOrThrowAsync(productTypeId,
            new ProductTypeNotFoundException(productTypeId), _productTypeReadOnlyRepository);

        ThrowIfQuantityIsInvalid(productType, quantity);

        return productType;
    }

    private async Task<Cart> CheckValidOnCreateItemAsync(Guid userId, Guid cartItemId)
    {
        var cartUserIdSpecification = new CartUserIdSpecification(userId);

        var cartIdSpecification = new EntityIdSpecification<Cart>(cartItemId);

        var cartItemIsNotDeletedSpecification = new CartItemIsNotDeletedSpecification();

        var specification = cartUserIdSpecification.And(cartIdSpecification).And(cartItemIsNotDeletedSpecification);

        var cartItem = Optional<Cart>.Of(await _cartReadOnlyRepository.GetAnyAsync(specification, "ProductType", true))
            .ThrowIfNotExist(new CartItemNotFoundException(cartItemId, userId)).Get();

        if (cartItem.ProductType is null) throw new ProductTypeNotFoundException(cartItem.ProductTypeId);

        return cartItem;
    }

    private static void ThrowIfQuantityIsInvalid(ProductType productType, int quantity)
    {
        if (productType.Quantity < quantity) throw new InvalidProductTypeQuantityException();
    }

    private async Task CheckValidOnCreateAsync(Guid userId, Guid shippingAddressId, IEnumerable<OrderItem> orderItems)
    {
        await EntityHelper.ThrowIfNotExistAsync(userId, new UserNotFoundException(userId),
            _userReadOnlyRepository);

        var shippingAddressUserIdSpecification = new ShippingAddressUserIdSpecification(userId);

        var shippingAddressIdSpecification = new EntityIdSpecification<ShippingAddress>(shippingAddressId);

        var specification = shippingAddressUserIdSpecification.And(shippingAddressIdSpecification);

        await EntityHelper.ThrowIfNotExistAsync(specification,
            new ShippingAddressNotFoundException(shippingAddressId, userId), _shippingAddressReadOnlyRepository);

        CheckOrderItems(orderItems);
    }


    private static void CheckOrderItems(IEnumerable<OrderItem> orderItems)
    {
        var orderItemIdSet = new HashSet<Guid>();

        foreach (var orderItem in orderItems)
        {
            if (orderItemIdSet.Contains(orderItem.ProductTypeId))
                throw new OrderItemConflictException(orderItem.ProductTypeId);

            orderItemIdSet.Add(orderItem.ProductTypeId);
        }
    }
}