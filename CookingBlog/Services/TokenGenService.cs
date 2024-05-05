using CookingBlog.Models.Requests;
using CookingBlog.Models.Responces;
using CookingBlog.Models;
using CookingBlog.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CookingBlog.Services;

public class TokenGenService : ITokenGenService
{
    private readonly string accessTokenSecret;
    private readonly int accessTokenTTLMinutes;
    private readonly int refreshTokenTTLDays;

    public TokenGenService(ISettings settings)
    {
        accessTokenSecret = settings.GetValue("Auth:AccessTokenSecret");
        accessTokenTTLMinutes = settings.GetValue<int>("Auth:AccessTokenTTLMinutes");
        refreshTokenTTLDays = settings.GetValue<int>("Auth:RefreshTokenTTLDays");
    }

    public AuthResponse Generate(GenerateTokenRequest request)
    {
        return new AuthResponse
        {
            AccessToken = AccessToken(request),
            RefreshToken = RefreshToken()
        };
    }

    private string AccessToken(GenerateTokenRequest request)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(accessTokenSecret));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("email", request.UserEmail),
                new Claim("user_id", $"{request.UserId}"),
                new Claim("account_id", $"{request.AccountId}"),
                new Claim("is_moderator", $"{request.IsModerator}".ToLower()),
            }),
            Expires = DateTime.Now.AddMinutes(accessTokenTTLMinutes),
            SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    private RefreshToken RefreshToken()
    {
        var randomBytes = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);

        return new RefreshToken
        {
            Token = Convert.ToBase64String(randomBytes),
            Expires = DateTime.Now.AddDays(refreshTokenTTLDays),
        };
    }
}
