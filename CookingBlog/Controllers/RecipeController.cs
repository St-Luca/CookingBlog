using CookingBlog.Models.Core;
using CookingBlog.Models.Requests;
using CookingBlog.Models.Responses;
using CookingBlog.Services.IntegratedServices.Responses;
using CookingBlog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers;

[ApiController]
[Route("api/recipe")]
public class RecipeController : CookingControllerBase
{
    private readonly ILogger<RecipeController> logger;
    private readonly IRecipeService recipeService;

    public RecipeController(ILogger<RecipeController> logger, IRecipeService recipeService)
    {
        this.logger = logger;
        this.recipeService = recipeService;
    }

    [HttpGet]
    public async Task<FoodApiResponseCollection?> Get(int count)
    {
        return await recipeService.GetRandomRecipes(count);
    }

    [HttpPost("add")]
    public ActionResult<Task> Add([FromBody] CreateRecipeRequest request)
    {
        recipeService.Add(request);

        return Ok();
    }

    [HttpPost("user")]
    public ActionResult<UserRecipesResponse> GetRecipesByUser()
    {
        return recipeService.GetRecipesByUser(UserId);
    }
}