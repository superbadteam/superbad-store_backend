using BuildingBlock.Core.Domain.Shared.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Core.Application.CQRS.Commands.OrderCommands.Requests;
using OrderManagement.Core.Application.CQRS.Queries.OrderQueries.Requests;
using OrderManagement.Core.Application.DTOs.OrderDTOs;

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
    public async Task<ActionResult<OrderDetailDto>> CreateAsync(CreateOrderDto dto)
    {
        var order = await _mediator.Send(new CreateOrderCommand(dto));

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