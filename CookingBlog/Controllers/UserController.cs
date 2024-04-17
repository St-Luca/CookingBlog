﻿using CookingBlog.Models.Requests;
using CookingBlog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPut("password")]
    public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        await userService.ChangePassword(request);
        return Ok();
    }
}