using BuildingBlock.Core.Application.CQRS;
using InventoryManagement.Core.Application.DTOs.ProductDTOs;

namespace InventoryManagement.Core.Application.CQRS.Commands.ProductCommands.Requests;

public record EditProductCommand(Guid ProductId, CreateOrEditProductDto Dto) : ICommand<ProductDetailDto>;