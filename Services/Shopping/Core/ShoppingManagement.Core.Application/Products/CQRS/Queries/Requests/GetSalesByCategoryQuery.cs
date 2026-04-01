using BuildingBlock.Core.Application.CQRS;
using ShoppingManagement.Core.Application.Categories.DTOs;

namespace ShoppingManagement.Core.Application.Products.CQRS.Queries.Requests;

public sealed record GetSalesByCategoryQuery : IQuery<List<CategoryDto>>;