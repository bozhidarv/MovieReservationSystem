using Microsoft.AspNetCore.Mvc;

namespace MovieReservationSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController(ILogger<HealthController> logger) : ControllerBase
{
    [HttpHead(Name = "GetHealthStatus")]
    public IResult Head()
    {
        logger.LogInformation($"Health check {DateTime.Now.ToShortDateString()}-{DateTime.Now.ToLongTimeString()}");
        return Results.Ok();
    }
}
