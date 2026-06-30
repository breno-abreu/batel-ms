using Microsoft.AspNetCore.Mvc;

namespace BatelMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            service = "Batel MS API",
            status = "Healthy",
            message = "API do Batel MS em execução."
        });
    }
}
