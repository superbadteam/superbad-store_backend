using BuildingBlock.Core.Application.CQRS;
using InventoryManagement.Core.Application.Categories.DTOs;

namespace InventoryManagement.Core.Application.Categories.CQRS.Commands.Requests;

public record CreateCategoryCommand(CreateCategoryDto Dto) : ICommand<CategoryDto>;