using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;
    private readonly IPasswordResetService passwordResetService;

    public UserController(IUserService userService, IPasswordResetService passwordResetService)
    {
        this.userService = userService;
        this.passwordResetService = passwordResetService;
    }

    //[HttpPut("password")]
    //public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    //{
    //    await userService.ChangePassword(Email, request);
    //    return Ok();
    //}

    //[AllowAnonymous]
    //[HttpPost("restore-password")]
    //public async Task<ActionResult> RestorePassword([FromBody] RestorePasswordRequest request)
    //{
    //    await passwordResetService.RestorePassword(request);
    //    return Ok();
    //}

    //[AllowAnonymous]
    //[HttpPost("reset-password")]
    //public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
    //{
    //    await passwordResetService.ResetPassword(request);
    //    return Ok();
    //}


}
