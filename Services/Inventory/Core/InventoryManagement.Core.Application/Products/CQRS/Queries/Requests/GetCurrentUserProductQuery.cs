using BuildingBlock.Core.Application.CQRS;
using InventoryManagement.Core.Application.Products.ProductDTOs;

namespace InventoryManagement.Core.Application.Products.CQRS.Queries.Requests;

public record GetCurrentUserProductQuery(Guid ProductId) : IQuery<ProductDetailDto>;

public record GetCurrentUserProductStringQuery(string ProductId) : IQuery<ProductDetailDto>;