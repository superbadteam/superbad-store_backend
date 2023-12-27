using BuildingBlock.Core.Domain.Shared.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Core.Application.Users.CQRS.Commands.Requests;
using OrderManagement.Core.Application.Users.DTOs;

namespace OrderManagement.Presentation.API.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("me/shipping-addresses")]
    [Authorize(Policy = Permissions.Product.View)]
    public async Task<ActionResult<ShippingAddressDto>> CreateShippingAddressAsync(CreateShippingAddressDto dto)
    {
        var shippingAddress = await _mediator.Send(new CreateShippingAddressCommand(dto));

        return Created("", shippingAddress);
    }

    [HttpPost("me/shipping-addresses/{id:guid}")]
    [Authorize(Policy = Permissions.Product.View)]
    public ActionResult<ShippingAddressDto> GetShippingAddressById()
    {
        throw new NotImplementedException();
    }
}