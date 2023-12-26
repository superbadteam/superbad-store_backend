using BuildingBlock.Core.Application.CQRS;
using InventoryManagement.Core.Application.Categories.DTOs;

namespace InventoryManagement.Core.Application.Categories.CQRS.Queries.Requests;

public record GetAllCategoriesQuery : IQuery<List<CategoryDto>>;