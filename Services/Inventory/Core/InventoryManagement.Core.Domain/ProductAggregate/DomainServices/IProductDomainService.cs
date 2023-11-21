using InventoryManagement.Core.Domain.ProductAggregate.Entities;
using InventoryManagement.Core.Domain.ProductAggregate.Entities.Enums;

namespace InventoryManagement.Core.Domain.ProductAggregate.DomainServices;

public interface IProductDomainService
{
    Task<Product> CreateAsync(string name, string description, Guid categoryId, ProductCondition condition);

    Task<Product> EditAsync(Guid id, string code, string name, double price, bool isAvailable,
        ProductCondition condition);

    Task<IEnumerable<Product>> DeleteManyAsync(IEnumerable<Guid> ids);

    ProductType CreateProductType(Product product, string name, int quantity, double price);

    void CreateProductImage(ProductType productType, string url);
}