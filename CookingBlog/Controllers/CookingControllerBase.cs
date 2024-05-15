using CookingBlog.Infrastructure;
using CookingBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers;

public class CookingControllerBase : ControllerBase
{
    private CookingJwt YolwiseJwt => new(User);
    protected int UserId => YolwiseJwt.UserId;
    protected string Email => YolwiseJwt.Email;
    protected int AccountId => YolwiseJwt.AccountId;
    protected bool IsModerator => YolwiseJwt.IsModerator;
}
