using BuildingBlock.Core.Domain.Exceptions;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using OrderManagement.Core.Domain.ProductAggregate.Entities;
using OrderManagement.Core.Domain.ProductAggregate.Entities.Enums;
using OrderManagement.Core.Domain.ProductAggregate.Exceptions;
using OrderManagement.Core.Domain.UserAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.Exceptions;

namespace OrderManagement.Core.Domain.ProductAggregate.DomainServices;

public class ProductDomainService : IProductDomainService
{
    private readonly IReadOnlyRepository<Product> _productReadOnlyRepository;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public ProductDomainService(IReadOnlyRepository<Product> productReadOnlyRepository,
        IReadOnlyRepository<User> userReadOnlyRepository)
    {
        _productReadOnlyRepository = productReadOnlyRepository;
        _userReadOnlyRepository = userReadOnlyRepository;
    }

    public async Task<Product> CreateAsync(Guid productId, Guid userId, string name, ProductCondition condition,
        string image, DateTime createdAt, string createdBy)
    {
        await CheckValidOnCreateAsync(productId, userId);

        return new Product(productId, userId, name, condition, image, createdAt, createdBy);
    }

    public async Task<Product> EditAsync(Guid id, string code, string name, double price, bool isAvailable,
        ProductCondition condition)
    {
        var product = await CheckValidOnEditAsync(id, code);

        // product.Code = code;
        // product.Name = name;
        // product.Price = price;
        // product.IsAvailable = isAvailable;
        // product.Type = type;
        // product.UpdatedAt = null;
        // product.UpdatedBy = null;
        //
        // return product;
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> DeleteManyAsync(IEnumerable<Guid> ids)
    {
        List<Product> products = new();

        foreach (var id in ids)
        {
            var product = await CheckValidOnDeleteAsync(id);

            products.Add(product);
        }

        return products;
    }

    public ProductType CreateProductType(Product product, Guid id, string name, int quantity, double price,
        string? imageUrl, DateTime createdAt, string createdBy)
    {
        return product.AddTypes(id, name, quantity, price, createdAt, createdBy);
    }

    private Task<Product> CheckValidOnDeleteAsync(Guid id)
    {
        return GetOrThrowAsync(id);
    }

    private async Task CheckValidOnCreateAsync(Guid productId, Guid userId)
    {
        await ThrowIfProductIsExist(productId);
        await ThrowIfUserIsNotExistAsync(userId);
    }

    private async Task ThrowIfProductIsExist(Guid productId)
    {
        Optional<bool>
            .Of(await _productReadOnlyRepository.CheckIfExistAsync(new EntityIdSpecification<Product>(productId)))
            .ThrowIfExist(new ProductConflictException(productId));
    }
    

    private async Task ThrowIfUserIsNotExistAsync(Guid userId)
    {
        Optional<bool>
            .Of(await _userReadOnlyRepository.CheckIfExistAsync(new EntityIdSpecification<User>(userId)))
            .ThrowIfNotExist(new UserNotFoundException(userId));
    }

    private async Task<Product> CheckValidOnEditAsync(Guid id, string code)
    {
        var product = await GetOrThrowAsync(id);

        // await ThrowIfExistAsync(id, code);

        return product;
    }

    private async Task<Product> GetOrThrowAsync(Guid id)
    {
        var productIdSpecification = new EntityIdSpecification<Product>(id);

        return Optional<Product>.Of(await _productReadOnlyRepository.GetAnyAsync(productIdSpecification))
            .ThrowIfNotExist(new ProductNotFoundException(id)).Get();
    }
}