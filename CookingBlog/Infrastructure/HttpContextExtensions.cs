using Microsoft.Net.Http.Headers;

namespace CookingBlog.Infrastructure;

public static class HttpContextExtensions
{
    private static readonly string refreshTokenKey = "refreshToken";

    public static void AddAuth(this HttpContext httpContext, string accessToken, string refreshToken, DateTime refreshExpire)
    {
        httpContext.Response.Headers.Authorization = accessToken;
        httpContext.Response.Headers.AccessControlExposeHeaders = HeaderNames.Authorization;
        httpContext.Response.Cookies.Append(refreshTokenKey, refreshToken, new CookieOptions
        {
            Expires = refreshExpire
        });
    }

    public static void RemoveAuth(this HttpContext httpContext)
    {
        httpContext.Response.Cookies.Delete(refreshTokenKey);
    }

    public static string GetRefreshToken(this HttpContext httpContext)
    {
        return httpContext.Request.Cookies[refreshTokenKey]!;
    }
}
