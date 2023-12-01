using BuildingBlock.Core.Domain.Shared.Constants.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Application.CQRS.Commands.Requests;
using Shared.Core.Application.DTOs;

namespace Shared.Presentation.API.Controllers;

[ApiController]
[Route("api")]
public class UploadController : ControllerBase
{
    private readonly IMediator _mediator;

    public UploadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [DisableRequestSizeLimit]
    [Authorize(Policy = Permissions.File.Upload)]
    public async Task<ActionResult<UploadImagesResponseDto>> CreateAsync(IEnumerable<IFormFile> images)
    {
        var response = await _mediator.Send(new UploadImageCommand(images));

        return Ok(response);
    }
}