using SaleManagement.Core.Domain.ProductAggregate.Entities;
using SaleManagement.Core.Domain.ProductAggregate.Entities.Enums;

namespace SaleManagement.Core.Domain.ProductAggregate.DomainServices;

public interface IProductDomainService
{
    Task<Product> CreateAsync(Guid productId, Guid userId, string name, string description, Guid categoryId,
        ProductCondition condition, DateTime createdAt, string createdBy);

    Task<Product> EditAsync(Guid id, string code, string name, double price, bool isAvailable,
        ProductCondition condition);

    Task<IEnumerable<Product>> DeleteManyAsync(IEnumerable<Guid> ids);

    ProductType CreateProductType(Product product, Guid id, string name, int quantity, double price, string? imageUrl,
        DateTime createdAt, string createdBy);

    void CreateProductImage(Product product, Guid id, string url, DateTime createdAt, string createdBy);

    void IncreaseSold(Product product, Guid productTypeId, int quantity);
}