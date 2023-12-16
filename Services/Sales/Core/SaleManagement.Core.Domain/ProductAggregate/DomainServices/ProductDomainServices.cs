using BuildingBlock.Core.Domain.Exceptions;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using SaleManagement.Core.Domain.CategoryAggregate.Entities;
using SaleManagement.Core.Domain.CategoryAggregate.Exceptions;
using SaleManagement.Core.Domain.ProductAggregate.Entities;
using SaleManagement.Core.Domain.ProductAggregate.Entities.Enums;
using SaleManagement.Core.Domain.ProductAggregate.Exceptions;
using SaleManagement.Core.Domain.UserAggregate.Entities;
using SaleManagement.Core.Domain.UserAggregate.Exceptions;

namespace SaleManagement.Core.Domain.ProductAggregate.DomainServices;

public class ProductDomainService : IProductDomainService
{
    private readonly IReadOnlyRepository<Category> _categoryReadOnlyRepository;
    private readonly IReadOnlyRepository<Product> _productReadOnlyRepository;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public ProductDomainService(IReadOnlyRepository<Product> productReadOnlyRepository,
        IReadOnlyRepository<Category> categoryReadOnlyRepository, IReadOnlyRepository<User> userReadOnlyRepository)
    {
        _productReadOnlyRepository = productReadOnlyRepository;
        _categoryReadOnlyRepository = categoryReadOnlyRepository;
        _userReadOnlyRepository = userReadOnlyRepository;
    }

    public async Task<Product> CreateAsync(Guid productId, Guid userId, string name, string description,
        Guid categoryId, ProductCondition condition, DateTime createdAt, string createdBy)
    {
        await CheckValidOnCreateAsync(productId, categoryId, userId);

        return new Product(productId, userId, name, description, categoryId, condition, createdAt, createdBy);
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
        return product.AddTypes(id, name, quantity, price, imageUrl, createdAt, createdBy);
    }

    public void CreateProductImage(Product product, Guid id, string url, DateTime createdAt, string createdBy)
    {
        product.AddImage(id, url, createdAt, createdBy);
    }

    public void IncreaseSold(Product product, Guid productTypeId, int quantity)
    {
        var productType = CheckValidOnIncreaseSold(product, productTypeId, quantity);

        productType.Quantity -= quantity;
        product.Sold += quantity;
    }

    private ProductType CheckValidOnIncreaseSold(Product product, Guid productTypeId, int quantity)
    {
        var productType = Optional<ProductType>
            .Of(product.Types.FirstOrDefault(type => type.Id == productTypeId))
            .ThrowIfNotExist(new ProductTypeNotFoundException(productTypeId, product.Id)).Get();

        if (productType.Quantity < quantity) throw new ProductTypeQuantityInvalidException();

        return productType;
    }

    private Task<Product> CheckValidOnDeleteAsync(Guid id)
    {
        return GetOrThrowAsync(id);
    }

    private async Task CheckValidOnCreateAsync(Guid productId, Guid categoryId, Guid userId)
    {
        await ThrowIfProductIsExist(productId);
        await ThrowIfUserIsNotExistAsync(userId);
        await CheckCategoryValidation(categoryId);
    }

    private async Task ThrowIfProductIsExist(Guid productId)
    {
        Optional<bool>
            .Of(await _productReadOnlyRepository.CheckIfExistAsync(new EntityIdSpecification<Product>(productId)))
            .ThrowIfExist(new ProductConflictException(productId));
    }

    private async Task CheckCategoryValidation(Guid categoryId)
    {
        var category = Optional<Category>
            .Of(await _categoryReadOnlyRepository.GetAnyAsync(new EntityIdSpecification<Category>(categoryId)))
            .ThrowIfNotExist(new CategoryNotFoundException(categoryId)).Get();

        if (category.ParentId == null) throw new ValidationException("Cannot choose a parent category");
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