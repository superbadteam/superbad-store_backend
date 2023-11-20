using BuildingBlock.Core.Application.CQRS;
using InventoryManagement.Core.Application.DTOs.ProductDTOs;

namespace InventoryManagement.Core.Application.CQRS.Queries.ProductQueries.Requests;

public record GetProductQuery(Guid ProductId) : IQuery<ProductDetailDto>;