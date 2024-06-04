using CookingBlog.Infrastructure;
using CookingBlog.Models.Requests;
using CookingBlog.Models.Responses;
using CookingBlog.Services;
using CookingBlog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers;

[Route("api/auth")]
[ApiController]
[AllowAnonymous]
public class AuthController : CookingControllerBase
{
    private readonly IPasswordResetService passwordResetService;
    private readonly IAuthService authService;
    private readonly IRegistrationService registrationService;

    public AuthController(IPasswordResetService passwordResetService, IAuthService authService, IRegistrationService registrationService)
    {
        this.authService = authService;
        this.passwordResetService = passwordResetService;
        this.registrationService = registrationService;
    }

    [HttpPost]
    public async Task<ActionResult> Authorization([FromBody] LoginRequest request)
    {
        var result = await authService.Authorization(new AuthorizationRequest
        {
            Email = request.Email,
            Password = request.Password,
        });

        if (result is null)
        {
            return BadRequest();
        }

        HttpContext.AddAuth(result.AccessToken, result.RefreshToken.Token, result.RefreshToken.Expires);

        return Ok();
    }

    [HttpPost("logout")]
    public ActionResult Logout()
    {
        HttpContext.RemoveAuth();

        return Ok();
    }

    [HttpPost("refresh")]
    public async Task<ActionResult> Token()
    {
        var refreshToken = HttpContext.GetRefreshToken();

        if (string.IsNullOrEmpty(refreshToken))
        {
            return Unauthorized();
    }

        var result = await authService.Refresh(new RefreshRequest
        {
            RefreshToken = refreshToken
        });

        HttpContext.AddAuth(result.AccessToken, result.RefreshToken.Token, result.RefreshToken.Expires);

        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("restore-password")]
    public async Task<ActionResult> RestorePassword([FromBody] RestorePasswordRequest request)
    {
        await passwordResetService.RestorePassword(request);
        return Ok();
    } 

    [AllowAnonymous]
    [HttpPost("reset-password")]
    public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
    {
        await passwordResetService.ResetPassword(request);
        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult<RegisterUserResult>> Register([FromBody] RegisterUserRequest createUserRequest)
    {
        return await registrationService.RegisterUser(1, createUserRequest);
    }

    [HttpPost("complete")]
    public async Task<ActionResult> Complete([FromBody] CompleteUserRequest completeUserRequest)
    {
        await registrationService.Complete(completeUserRequest);

        return Ok();
    }
}
