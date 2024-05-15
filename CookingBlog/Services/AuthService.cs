using CookingBlog.Infrastructure;
using CookingBlog.Models;
using CookingBlog.Models.Core;
using CookingBlog.Models.Requests;
using CookingBlog.Models.Responces;
using CookingBlog.Services.Interfaces;
using System.Net;
using System.Runtime;

namespace CookingBlog.Services;

public class AuthService : IAuthService
{
    private static readonly HashSet<Role> authRoles = new HashSet<Role>{ Role.Moderator, Role.User};

    private readonly IUserService userService;
    private readonly ITokenGenService tokenGenService;
    private readonly IUserTokensService userTokensService;

    public AuthService(
        IUserService userService,
        ITokenGenService tokenGenService,
        IUserTokensService userTokensService)
    {
        this.userService = userService;
        this.tokenGenService = tokenGenService;
        this.userTokensService = userTokensService;
    }

    public async Task<AuthResponse?> Authorization(AuthorizationRequest loginRequest)
    {
        var user = await userService.GetUser(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return default;
        }

        if (user.Roles.All(x => !authRoles.Contains(x)))
        {
            throw new CookingHttpRequestException("don't have permissions", HttpStatusCode.Forbidden);
        }

        return await GenerateTokens(user);
    }

    public async Task<AuthResponse> Refresh(RefreshRequest refreshRequest)
    {
        var userToken = await userTokensService.Get(refreshRequest.RefreshToken);

        if (userToken == null || userToken.IsExpired())
        {
            throw new CookingHttpRequestException(HttpStatusCode.Unauthorized);
        }

        var user = await userService.GetById(userToken.UserId);

        if (user == null)
        {
            throw new CookingHttpRequestException("user doesn't exist", httpStatusCode: HttpStatusCode.Unauthorized);
        }

        return await GenerateTokens(user);
    }

    private async Task<AuthResponse> GenerateTokens(User user)
    {
        var auth = tokenGenService.Generate(new GenerateTokenRequest
        {
            UserEmail = user.Email,
            UserId = user.Id,
            IsModerator = user.IsModerator()
        });

        var userToken = await userTokensService.Add(new UserToken
        {
            UserId = user.Id,
            RefreshToken = auth.RefreshToken.Token,
            RefreshExpire = auth.RefreshToken.Expires,
            AccessToken = auth.AccessToken,
            CreatedDate = DateTime.Now
        });

        if (userToken == null)
        {
            throw new CookingHttpRequestException(httpStatusCode: HttpStatusCode.Unauthorized);
        }

        return auth;
    }
}
