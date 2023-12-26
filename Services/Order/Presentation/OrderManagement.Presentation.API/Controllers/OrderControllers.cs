using BuildingBlock.Core.Domain.Shared.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Core.Application.Orders.CQRS.Commands.Requests;
using OrderManagement.Core.Application.Orders.CQRS.Queries.Requests;
using OrderManagement.Core.Application.Orders.DTOs;
using OrderManagement.Core.Application.Orders.DTOs.Enums;

namespace OrderManagement.Presentation.API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderControllers : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderControllers(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Policy = Permissions.Product.View)]
    public async Task<ActionResult<OrderDetailDto>> CreateAsync([FromQuery] AddItemMethod method, CreateOrderDto dto)
    {
        var order = await _mediator.Send(new CreateOrderCommand(method, dto));

        return CreatedAtAction(nameof(GetCurrentUserOrderByIdAsync), new { id = order.Id }, order);
    }

    [HttpGet("me/{id:guid}")]
    [ActionName(nameof(GetCurrentUserOrderByIdAsync))]
    [Authorize(Policy = Permissions.Product.View)]
    public async Task<ActionResult<OrderDetailDto>> GetCurrentUserOrderByIdAsync(Guid id)
    {
        var order = await _mediator.Send(new GetCurrentUserOrderQuery(id));

        return Ok(order);
    }
}