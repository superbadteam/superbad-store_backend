using BuildingBlock.Core.Application.CQRS;
using SaleManagement.Core.Application.Products.DTOs;

namespace SaleManagement.Core.Application.Products.CQRS.Queries.Requests;

public record GetProductQuery(Guid ProductId) : IQuery<ProductDetailDto>;