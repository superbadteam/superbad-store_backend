using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using ReviewManagement.Core.Domain.ProductAggregate.Entities;
using ReviewManagement.Core.Domain.ProductAggregate.Exceptions;

namespace ReviewManagement.Core.Domain.ProductAggregate.DomainServices;

public class ProductDomainService : IProductDomainService
{
    private readonly IReadOnlyRepository<Product> _productReadOnlyRepository;

    public ProductDomainService(IReadOnlyRepository<Product> productReadOnlyRepository)
    {
        _productReadOnlyRepository = productReadOnlyRepository;
    }

    public async Task<Product> CreateAsync(Guid productId, Guid userId, string name, string imageUrl,
        DateTime createdAt, string createdBy)
    {
        await CheckValidOnCreateAsync(productId);

        return new Product(productId, userId, name, imageUrl, createdAt, createdBy);
    }

    public ProductType CreateProductType(Product product, Guid id, string name, double price, DateTime createdAt,
        string createdBy)
    {
        return product.AddTypes(id, name, price, createdAt, createdBy);
    }

    private async Task CheckValidOnCreateAsync(Guid productId)
    {
        await EntityHelper.ThrowIfExistAsync(productId, new ProductConflictException(productId),
            _productReadOnlyRepository);
    }
}