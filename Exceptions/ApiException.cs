using System.Net;
using System.Text.Json;

namespace MovieReservationSystem.Exceptions;

public abstract class ApiException(string message, HttpStatusCode statusCode) : Exception(message)
{
    public HttpStatusCode StatusCode { get; set; } = statusCode;

    public string GetJson()
    {
        return JsonSerializer.Serialize(new { statusCode = (int)StatusCode, message = Message });
    }
}

public class NotFoundException(string message) : ApiException(message, HttpStatusCode.NotFound);

public class BadRequestException(string message) : ApiException(message, HttpStatusCode.BadRequest);

public class InternalServerException(string message) : ApiException(message, HttpStatusCode.InternalServerError);
