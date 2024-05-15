using CookingBlog.Models.Requests;
using CookingBlog.Models.Responses;
using CookingBlog.Services;
using CookingBlog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : CookingControllerBase
{
    private readonly IUserService userService;   

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPut("password")]
    public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        await userService.ChangePassword(Email, request);
        return Ok();
    }
}
