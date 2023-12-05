using BuildingBlock.Core.Application.DTOs;
using BuildingBlock.Core.Domain.Shared.Constants;
using InventoryManagement.Core.Application.CQRS.Commands.ProductCommands.Requests;
using InventoryManagement.Core.Application.CQRS.Queries.ProductQueries.Requests;
using InventoryManagement.Core.Application.DTOs.ProductDTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Presentation.API.Controller;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("me")]
    [Authorize(Policy = Permissions.Product.View)]
    public async Task<ActionResult<FilterAndPagingResultDto<ProductSummaryDto>>> GetCurrentUserProductsAsync(
        [FromQuery] FilterAndPagingCurrentUserProductsDto dto)
    {
        var products = await _mediator.Send(new FilterAndPagingCurrentUserProductsQuery(dto));

        return Ok(products);
    }

    [HttpGet("me/{id:guid}")]
    [ActionName(nameof(GetCurrentUserProductByIdAsync))]
    [Authorize(Policy = Permissions.Product.View)]
    public async Task<ActionResult<ProductDetailDto>> GetCurrentUserProductByIdAsync(Guid id)
    {
        var product = await _mediator.Send(new GetCurrentUserProductQuery(id));

        return Ok(product);
    }

    [HttpPost]
    [Authorize(Policy = Permissions.Product.Create)]
    public async Task<ActionResult<ProductDetailDto>> CreateAsync([FromBody] CreateOrEditProductDto dto)
    {
        var product = await _mediator.Send(new CreateProductCommand(dto));

        return CreatedAtAction(nameof(GetCurrentUserProductByIdAsync), new { id = product.Id }, product);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Policy = Permissions.Product.Edit)]
    public async Task<ActionResult<ProductDetailDto>> EditAsync([FromBody] CreateOrEditProductDto dto, Guid id)
    {
        var product = await _mediator.Send(new EditProductCommand(id, dto));

        return product;
    }

    [HttpDelete]
    [Authorize(Policy = Permissions.Product.Delete)]
    public async Task<ActionResult> DeleteAsync(DeleteManyProductsDto dto)
    {
        await _mediator.Send(new DeleteManyProductsCommand(dto));

        return NoContent();
    }
}