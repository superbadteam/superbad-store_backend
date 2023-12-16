using OrderManagement.Core.Domain.ProductAggregate.Entities;
using OrderManagement.Core.Domain.ProductAggregate.Entities.Enums;

namespace OrderManagement.Core.Domain.ProductAggregate.DomainServices;

public interface IProductDomainService
{
    Task<Product> CreateAsync(Guid productId, Guid userId, string name, ProductCondition condition,
        string image, DateTime createdAt, string createdBy);

    Task<Product> EditAsync(Guid id, string code, string name, double price, bool isAvailable,
        ProductCondition condition);

    Task<IEnumerable<Product>> DeleteManyAsync(IEnumerable<Guid> ids);

    ProductType CreateProductType(Product product, Guid id, string name, int quantity, double price, string? imageUrl,
        DateTime createdAt, string createdBy);

    void Sell(Product product, Guid productTypeId, int quantity);
}