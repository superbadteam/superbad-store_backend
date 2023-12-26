using BuildingBlock.Core.Application.CQRS;
using InventoryManagement.Core.Application.Categories.DTOs;

namespace InventoryManagement.Core.Application.Products.CQRS.Queries.Requests;

public record GetAllCategoriesQuery : IQuery<List<CategoryDto>>;