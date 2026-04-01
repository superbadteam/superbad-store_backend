using BuildingBlock.Core.Domain.Shared.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Core.Application.Orders.CQRS.Queries.Requests;
using OrderManagement.Core.Application.Orders.DTOs;
using OrderManagement.Core.Application.Users.CQRS.Queries.Requests;
using OrderManagement.Core.Application.Users.DTOs;

namespace OrderManagement.Presentation.API.Controllers;

[ApiController]
[Route("api")]
public class AnalyticController : ControllerBase
{
    private readonly IMediator _mediator;

    public AnalyticController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("sale-dashboard")]
    [Authorize(Policy = Permissions.Product.View)]
    public async Task<ActionResult<SalesOverviewResponse>> GetSaleDashboardAsync()
    {
        var salesOverview = await _mediator.Send(new GetSalesOverviewQuery());

        return Ok(salesOverview);
    }

    [HttpGet("total-count-statistics")]
    public async Task<ActionResult<TotalCountStatDto>> GetTotalCountStatisticsAsync()
    {
        var totalCountStat = await _mediator.Send(new GetTotalCountStatisticsQuery());

        return Ok(totalCountStat);
    }

    [HttpGet("user-locations")]
    public async Task<ActionResult<LocationUserCountDto>> GetUserLocationsAsync()
    {
        var userDistribution = await _mediator.Send(new GetUserDistributionQuery());

        return Ok(userDistribution);
    }
}