using InventoryManagement.Core.Application.CQRS.Queries.ProductQueries.Requests;
using InventoryManagement.Core.Application.DTOs.CategoryDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Presentation.API.Controller;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllAsync()
    {
        var categories = await _mediator.Send(new GetAllCategoriesQuery());

        return Ok(categories);
    }
}