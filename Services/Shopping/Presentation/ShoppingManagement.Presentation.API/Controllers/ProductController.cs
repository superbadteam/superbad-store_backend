using BuildingBlock.Core.Application.DTOs;
using BuildingBlock.Core.Domain.Shared.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingManagement.Core.Application.Products.CQRS.Commands.Requests;
using ShoppingManagement.Core.Application.Products.CQRS.Queries.Requests;
using ShoppingManagement.Core.Application.Products.DTOs;

namespace ShoppingManagement.Presentation.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<FilterAndPagingResultDto<ProductSummaryDto>>> GetAllAsync(
        [FromQuery] FilterAndPagingProductsDto dto)
    {
        var products = await _mediator.Send(new FilterAndPagingProductsQuery(dto));

        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductDetailDto>> GetProductAsync(Guid id)
    {
        var product = await _mediator.Send(new GetProductQuery(id));

        return Ok(product);
    }
    
    [HttpGet("{id:guid}/recommendations")]
    public async Task<ActionResult<List<ProductSummaryDto>>> GetProductRecommendationsAsync(Guid id)
    {
        var recommendations = await _mediator.Send(new GetProductRecommendationsQuery(id));

        return Ok(recommendations);
    }

    [HttpGet("recommended")]
    [Authorize(Policy = Permissions.Product.View)]
    public async Task<ActionResult<List<ProductSummaryDto>>> GetRecommendedProductsAsync()
    {
        var products = await _mediator.Send(new GetRecommendedProductsQuery());

        return Ok(new { Products = products });
    }

    [HttpPost("sync-sold")]
    [AllowAnonymous]
    public async Task<IActionResult> SyncSoldAsync()
    {
        await _mediator.Send(new SyncSoldCommand());

        return NoContent();
    }
}