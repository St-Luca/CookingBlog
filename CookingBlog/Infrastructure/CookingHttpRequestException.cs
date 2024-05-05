using System.Net;

namespace CookingBlog.Infrastructure;

public class CookingHttpRequestException : HttpRequestException
{
    public CookingHttpRequestException(Exception? exception = null, string? message = null,
        HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest) : base(message, exception, httpStatusCode)
    {
    }

    public CookingHttpRequestException(string? message = null,
        HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest) : base(message, null, httpStatusCode)
    {
    }

    public CookingHttpRequestException(HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest) : base(null, null,
        httpStatusCode)
    {
    }
}
