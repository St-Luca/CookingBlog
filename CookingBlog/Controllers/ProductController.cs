using CookingBlog.Models.Requests;
using CookingBlog.Services;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController : CookingControllerBase
{
    [HttpGet("recipeId:int")]
    public async Task<ActionResult> GetProductsByRecipeId(int recipeId)
    {
        return await productService.GetProductsByRecipeId(recipeId);
        //await pro.ChangePassword(Email, request);
        //return Ok();
    }
}
