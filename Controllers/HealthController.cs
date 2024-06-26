using Microsoft.AspNetCore.Mvc;

namespace MovieReservationSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    private readonly ILogger<HealthController> _logger;

    public HealthController(ILogger<HealthController> logger)
    {
        _logger = logger;
    }

    [HttpHead(Name = "GetHealthStatus")]
    public IResult Head()
    {
        return Results.Ok();
    }
}
