using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using OrderManagement.Core.Domain.OrderAggregate.DomainServices.Abstractions;
using OrderManagement.Core.Domain.OrderAggregate.Entities;
using OrderManagement.Core.Domain.OrderAggregate.Exceptions;
using OrderManagement.Core.Domain.ProductAggregate.Entities;
using OrderManagement.Core.Domain.ProductAggregate.Exceptions;
using OrderManagement.Core.Domain.UserAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.Exceptions;
using OrderManagement.Core.Domain.UserAggregate.Specifications;

namespace OrderManagement.Core.Domain.OrderAggregate.DomainServices.Implementations;

public class OrderDomainService : IOrderDomainService
{
    private readonly IReadOnlyRepository<ProductType> _productTypeReadOnlyRepository;
    private readonly IReadOnlyRepository<ShippingAddress> _shippingAddressReadOnlyRepository;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public OrderDomainService(IReadOnlyRepository<ProductType> productTypeReadOnlyRepository,
        IReadOnlyRepository<User> userReadOnlyRepository,
        IReadOnlyRepository<ShippingAddress> shippingAddressReadOnlyRepository)
    {
        _productTypeReadOnlyRepository = productTypeReadOnlyRepository;
        _userReadOnlyRepository = userReadOnlyRepository;
        _shippingAddressReadOnlyRepository = shippingAddressReadOnlyRepository;
    }

    public async Task<OrderItem> CreateItemAsync(Guid productTypeId, int quantity)
    {
        var productType = await CheckValidOnCreateItemAsync(productTypeId, quantity);

        return new OrderItem(productTypeId, quantity, productType.Price * quantity);
    }

    public async Task<Order> CreateAsync(Guid userId, Guid shippingAddressId, List<OrderItem> orderItems)
    {
        await CheckValidOnCreateAsync(userId, shippingAddressId, orderItems);

        return new Order(userId, shippingAddressId, orderItems);
    }

    private async Task<ProductType> CheckValidOnCreateItemAsync(Guid productTypeId, int quantity)
    {
        var productType = await EntityHelper.GetOrThrowAsync(productTypeId,
            new ProductTypeNotFoundException(productTypeId), _productTypeReadOnlyRepository);

        ThrowIfQuantityIsInvalid(productType, quantity);

        return productType;
    }

    private static void ThrowIfQuantityIsInvalid(ProductType productType, int quantity)
    {
        if (productType.Quantity < quantity) throw new ProductTypeQuantityInvalidException();
    }

    private async Task CheckValidOnCreateAsync(Guid userId, Guid shippingAddressId, IEnumerable<OrderItem> orderItems)
    {
        var user = await EntityHelper.GetOrThrowAsync(userId, new UserNotFoundException(userId),
            _userReadOnlyRepository);

        var shippingAddressUserIdSpecification = new ShippingAddressUserIdSpecification(user.Id);

        var shippingAddressIdSpecification = new EntityIdSpecification<ShippingAddress>(shippingAddressId);

        var specification = shippingAddressUserIdSpecification.And(shippingAddressIdSpecification);

        await EntityHelper.ThrowIfNotExist(shippingAddressId,
            new ShippingAddressNotFoundException(shippingAddressId, user.Id), _shippingAddressReadOnlyRepository,
            specification);

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