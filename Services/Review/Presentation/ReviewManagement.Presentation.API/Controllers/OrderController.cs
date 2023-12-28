using BuildingBlock.Core.Domain.Shared.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewManagement.Core.Application.Orders.CQRS.Query.Events;
using ReviewManagement.Core.Application.Orders.DTOs;

namespace ReviewManagement.Presentation.API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("me/reviewable")]
    [Authorize(Policy = Permissions.Product.View)]
    public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetCurrentUserReviewableOrderItemsAsync()
    {
        var orderItems = await _mediator.Send(new GetCurrentUserReviewableOrderItemsAsync());

        return Ok(orderItems);
    }
}