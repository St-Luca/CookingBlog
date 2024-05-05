using System.Net;

namespace CookingBlog.Infrastructure;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, ILogger logger)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e) when (e is HttpRequestException yException)
        {
            await HandleException(httpContext, yException, yException.StatusCode ?? HttpStatusCode.BadRequest, logger);
        }
        catch (Exception e) when (e is HttpRequestException)
        {
            await HandleException(httpContext, e, HttpStatusCode.BadRequest, logger);
        }
        catch (Exception e)
        {
            await HandleException(httpContext, e, HttpStatusCode.InternalServerError, logger);
        }
    }

    private async Task HandleException(HttpContext httpContext, Exception exception, HttpStatusCode code,
        ILogger logger)
    {
        logger.LogError(exception.Message);
        httpContext.Response.StatusCode = (int)code;

        await httpContext.Response.WriteAsync(exception.Message);
    }
}
