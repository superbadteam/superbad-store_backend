using BuildingBlock.Core.Application;
using BuildingBlock.Core.Domain.Exceptions;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using InventoryManagement.Core.Domain.CategoryAggregate.Entities;
using InventoryManagement.Core.Domain.CategoryAggregate.Exceptions;
using InventoryManagement.Core.Domain.ProductAggregate.DomainServices.Abstractions;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;
using InventoryManagement.Core.Domain.ProductAggregate.Entities.Enums;
using InventoryManagement.Core.Domain.ProductAggregate.Exceptions;

namespace InventoryManagement.Core.Domain.ProductAggregate.DomainServices.Implementations;

public class ProductDomainService : IProductDomainService
{
    private readonly IReadOnlyRepository<Category> _categoryReadOnlyRepository;
    private readonly ICurrentUser _currentUser;
    private readonly IReadOnlyRepository<Product> _productReadOnlyRepository;

    public ProductDomainService(IReadOnlyRepository<Product> productReadOnlyRepository,
        IReadOnlyRepository<Category> categoryReadOnlyRepository, ICurrentUser currentUser)
    {
        _productReadOnlyRepository = productReadOnlyRepository;
        _categoryReadOnlyRepository = categoryReadOnlyRepository;
        _currentUser = currentUser;
    }

    public async Task<Product> CreateAsync(string name, string description, Guid categoryId, ProductCondition condition)
    {
        await CheckValidOnCreateAsync(categoryId);

        return new Product(name, description, categoryId, condition, _currentUser.Id);
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

    public ProductType CreateProductType(Product product, string name, int quantity, double price, string? imageUrl)
    {
        return product.AddTypes(name, quantity, price, imageUrl);
    }

    public void CreateProductImage(Product product, string url)
    {
        product.AddImage(url);
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

    private async Task CheckValidOnCreateAsync(Guid categoryId)
    {
        await CheckCategoryValidation(categoryId);
    }

    private async Task CheckCategoryValidation(Guid categoryId)
    {
        var category = Optional<Category>
            .Of(await _categoryReadOnlyRepository.GetAnyAsync(new EntityIdSpecification<Category>(categoryId)))
            .ThrowIfNotExist(new CategoryNotFoundException(categoryId)).Get();

        if (category.ParentId == null) throw new ValidationException("Cannot choose a parent category");
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