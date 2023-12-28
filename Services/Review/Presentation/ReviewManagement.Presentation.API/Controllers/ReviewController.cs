using BuildingBlock.Core.Domain.Shared.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewManagement.Core.Application.Reviews.CQRS.Commands.Requests;
using ReviewManagement.Core.Application.Reviews.DTOs;

namespace ReviewManagement.Presentation.API.Controllers;

[ApiController]
[Route("api/reviews")]
public class ReviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{orderItemId:guid}")]
    [Authorize(Policy = Permissions.Product.View)]
    public async Task<ActionResult<ReviewDto>> CreateAsync([FromBody] CreateReviewDto dto, Guid orderItemId)
    {
        var review = await _mediator.Send(new CreateReviewCommand(orderItemId, dto));

        return Created("", review);
    }
}