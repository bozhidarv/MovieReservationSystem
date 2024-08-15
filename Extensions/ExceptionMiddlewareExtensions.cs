using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using MovieReservationSystem.Exceptions;

namespace MovieReservationSystem.Extensions;

public static class ExceptionMiddlewareExtension
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    ApiException? apiException = contextFeature.Error as ApiException ?? new InternalServerException($"Something went wrong: {contextFeature.Error.Message}");
                    context.Response.StatusCode = (int)apiException.StatusCode;

                    logger.LogError($"Something went wrong: {contextFeature.Error.Message}");
                    await context.Response.WriteAsync(apiException.GetJson());
                }
            });
        });
    }
}