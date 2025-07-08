using System.Net;
using System.Text.Json;
using ErrorOr;

namespace Portify.API.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var errorResponse = Error.Failure($"An unexpected error occurred: {exception.Message}");
        string json = JsonSerializer.Serialize(new { Errors = new[] { errorResponse } });

        return context.Response.WriteAsync(json);
    }
}

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app)
        // ReSharper disable once ArrangeMethodOrOperatorBody
    {
        return app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
