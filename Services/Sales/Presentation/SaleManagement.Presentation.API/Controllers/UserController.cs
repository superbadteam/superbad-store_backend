using BuildingBlock.Core.Domain.Shared.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaleManagement.Core.Application.CQRS.Commands.UserCommands.Requests;
using SaleManagement.Core.Application.CQRS.Queries.UserQueries.Requests;
using SaleManagement.Core.Application.DTOs.UserDTOs;

namespace SaleManagement.Presentation.API.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("cart")]
    [Authorize(Policy = Permissions.Product.View)]
    public async Task<ActionResult<CartDto>> GetAllAsync([FromQuery] AddToCartDto dto)
    {
        var users = await _mediator.Send(new AddToCartCommand(dto));

        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserDto>> GetByIdAsync(Guid id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery(id));

        return Ok(user);
    }
}