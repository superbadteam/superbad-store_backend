using Microsoft.AspNetCore.Mvc;

namespace Shared.Presentation.API.Controllers;

[ApiController]
[Route("api/health")]
public class HealthCheckController : ControllerBase
{
    [HttpGet]
    public ActionResult GetHealthCheck()
    {
        return NoContent();
    }
}