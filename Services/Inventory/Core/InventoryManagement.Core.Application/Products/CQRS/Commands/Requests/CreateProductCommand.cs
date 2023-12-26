using BuildingBlock.Core.Application.CQRS;
using InventoryManagement.Core.Application.Products.ProductDTOs;

namespace InventoryManagement.Core.Application.Products.CQRS.Commands.Requests;

public record CreateProductCommand(CreateOrEditProductDto Dto) : ICommand<ProductDetailDto>;