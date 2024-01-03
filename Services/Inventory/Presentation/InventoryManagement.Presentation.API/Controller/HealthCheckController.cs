using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Presentation.API.Controller;

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