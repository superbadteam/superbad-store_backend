using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingManagement.Core.Application.Categories.DTOs;
using ShoppingManagement.Core.Application.Products.CQRS.Queries.Requests;
using ShoppingManagement.Core.Application.Products.DTOs;

namespace ShoppingManagement.Presentation.API.Controllers;

[ApiController]
[Route("api")]
public class AnalyticController : ControllerBase
{
    private readonly IMediator _mediator;

    public AnalyticController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("most-sold-products")]
    public async Task<ActionResult<List<ProductSummaryDto>>> GetMostSoldProductsAsync()
    {
        var products = await _mediator.Send(new GetMostSoldProductsQuery());

        return Ok(products);
    }

    [HttpGet("sales-by-category")]
    public async Task<ActionResult<List<CategoryDto>>> GetSalesByCategoryAsync()
    {
        var categories = await _mediator.Send(new GetSalesByCategoryQuery());

        return Ok(categories);
    }
}