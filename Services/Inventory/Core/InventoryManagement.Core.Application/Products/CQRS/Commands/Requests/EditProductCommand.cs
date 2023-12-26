using BuildingBlock.Core.Application.CQRS;
using InventoryManagement.Core.Application.Products.ProductDTOs;

namespace InventoryManagement.Core.Application.Products.CQRS.Commands.Requests;

public record EditProductCommand(Guid ProductId, CreateOrEditProductDto Dto) : ICommand<ProductDetailDto>;