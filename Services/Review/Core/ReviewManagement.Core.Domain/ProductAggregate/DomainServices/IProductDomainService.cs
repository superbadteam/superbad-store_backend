using ReviewManagement.Core.Domain.ProductAggregate.Entities;

namespace ReviewManagement.Core.Domain.ProductAggregate.DomainServices;

public interface IProductDomainService
{
    Task<Product> CreateAsync(Guid productId, Guid userId, string name, string imageUrl, DateTime createdAt,
        string createdBy);

    ProductType CreateProductType(Product product, Guid id, string name, double price, DateTime createdAt,
        string createdBy);
}