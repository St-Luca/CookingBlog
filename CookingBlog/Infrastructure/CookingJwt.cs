﻿using System.Net;
using System.Security.Claims;

namespace CookingBlog.Infrastructure;

public class CookingJwt
{
    private readonly ClaimsPrincipal user;

    public CookingJwt(ClaimsPrincipal user)
    {
        this.user = user;
    }

    public int UserId => ClaimValue<int>("user_id");
    public string Email => ClaimValue<string>(ClaimTypes.Email);
    public int AccountId => ClaimValue<int>("account_id");
    public bool IsModerator => ClaimValue<bool>("is_moderator");

    private T ClaimValue<T>(string claimType)
    {
        var claim = user.FindFirstValue(claimType);

        if (string.IsNullOrEmpty(claim))
        {
            throw new CookingHttpRequestException(HttpStatusCode.Unauthorized);
        }

        return claim.ToJson().FromJson<T>();
    }
}
