using BuildingBlock.Core.Application.CQRS;
using InventoryManagement.Core.Application.DTOs.CategoryDTOs;

namespace InventoryManagement.Core.Application.CQRS.Queries.ProductQueries.Requests;

public record GetAllCategoriesQuery : IQuery<List<CategoryDto>>;