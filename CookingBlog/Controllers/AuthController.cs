using CookingBlog.Models.Requests;
using CookingBlog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IPasswordResetService passwordResetService;
    private readonly IAuthService authService;

    public AuthController(IPasswordResetService passwordResetService, IAuthService authService)
    {
        this.authService = authService;
        this.passwordResetService = passwordResetService;
    }

    [AllowAnonymous]
    [HttpPost("restore-password")]
    public async Task<ActionResult> RestorePassword([FromBody] RestorePasswordRequest request)
    {
        await passwordResetService.RestorePassword(request);
        return Ok();
    } 
}
