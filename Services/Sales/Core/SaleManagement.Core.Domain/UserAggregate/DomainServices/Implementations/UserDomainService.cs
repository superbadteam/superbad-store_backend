using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using SaleManagement.Core.Domain.ProductAggregate.Entities;
using SaleManagement.Core.Domain.ProductAggregate.Exceptions;
using SaleManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;
using SaleManagement.Core.Domain.UserAggregate.Entities;
using SaleManagement.Core.Domain.UserAggregate.Exceptions;
using SaleManagement.Core.Domain.UserAggregate.Specifications;

namespace SaleManagement.Core.Domain.UserAggregate.DomainServices.Implementations;

public class UserDomainService : IUserDomainService
{
    private readonly IReadOnlyRepository<Cart> _cartReadOnlyRepository;
    private readonly IReadOnlyRepository<ProductType> _productTypeReadOnlyRepository;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public UserDomainService(IReadOnlyRepository<User> userReadOnlyRepository,
        IReadOnlyRepository<ProductType> productTypeReadOnlyRepository,
        IReadOnlyRepository<Cart> cartReadOnlyRepository)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _productTypeReadOnlyRepository = productTypeReadOnlyRepository;
        _cartReadOnlyRepository = cartReadOnlyRepository;
    }

    public async Task<User> CreateAsync(Guid id, string name, DateTime createdAt, string createdBy)
    {
        await CheckValidOnCreateAsync(id);

        var user = new User(id, name, createdAt, createdBy);

        return user;
    }

    public async Task AddToCartAsync(User user, Guid productTypeId, int quantity)
    {
        var productType = await CheckValidOnAddToCartAsync(user, productTypeId, quantity);

        user.AddToCart(productType, quantity);

        user.TotalPrice += productType.Price * quantity;
    }

    private async Task<ProductType> CheckValidOnAddToCartAsync(User user, Guid productTypeId, int quantity)
    {
        var productType = await GetOrThrowProductTypeAsync(productTypeId);

        ThrowIfQuantityIsInvalid(productType, quantity);

        await ThrowIfProductTypeIsExistInCart(user, productTypeId);

        return productType;
    }

    private static void ThrowIfQuantityIsInvalid(ProductType productType, int quantity)
    {
        if (productType.Quantity < quantity) throw new ProductTypeQuantityInvalidException();
    }

    private async Task ThrowIfProductTypeIsExistInCart(User user, Guid productTypeId)
    {
        var cartProductTypeIdSpecification = new CartProductTypeIdSpecification(user.Id, productTypeId);

        Optional<Cart>.Of(await _cartReadOnlyRepository.GetAnyAsync(cartProductTypeIdSpecification))
            .ThrowIfExist(new CartConflictException(productTypeId));
    }

    private async Task<ProductType> GetOrThrowProductTypeAsync(Guid productTypeId)
    {
        var productTypeIdSpecification = new EntityIdSpecification<ProductType>(productTypeId);

        return Optional<ProductType>
            .Of(await _productTypeReadOnlyRepository.GetAnyAsync(productTypeIdSpecification, "Product.Images"))
            .ThrowIfNotExist(new ProductTypeNotFoundException(productTypeId)).Get();
    }

    private async Task CheckValidOnCreateAsync(Guid id)
    {
        await ThrowIfExistAsync(id);
    }

    private async Task ThrowIfExistAsync(Guid id)
    {
        var userIdSpecification = new UserIdSpecification(id);

        Optional<bool>.Of(await _userReadOnlyRepository.CheckIfExistAsync(userIdSpecification))
            .ThrowIfExist(new UserConflictException(id));
    }
}