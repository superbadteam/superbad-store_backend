using BuildingBlock.Core.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<ActionResult<ProductDetailDto>> GetCurrentUserProductByIdAsync(Guid id)
    {
        var product = await _mediator.Send(new GetProductQuery(id));

        return Ok(product);
    }
}