using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Core.Application.Locations.CQRS.Queries.Requests;
using OrderManagement.Core.Application.Locations.DTOs;

namespace OrderManagement.Presentation.API.Controllers;

[ApiController]
[Route("api/locations")]
public class LocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityDto>>> GetAllAsync()
    {
        var locations = await _mediator.Send(new GetAllLocationsQuery());

        return Ok(locations);
    }
}