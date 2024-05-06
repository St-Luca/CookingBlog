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
    private const string accessTokenSecret = "dP1uH9o4KemsWOHyvYwy0UPmquikIVnS";
    private const int accessTokenTTLMinutes = 1440;
    private const int refreshTokenTTLDays = 7;

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
