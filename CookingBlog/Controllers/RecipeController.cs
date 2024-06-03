using CookingBlog.Models;
using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers;

[ApiController]
[Route("api/catalog")]
public class RecipeController : CookingControllerBase
{
    private readonly ILogger<RecipeController> _logger;

    private readonly IFoodApiRecipeService _apiRecipeService;
    //private readonly ICatalogService catalogService;

    public RecipeController(ILogger<RecipeController> logger, IFoodApiRecipeService apiRecipeService)//, ICatalogService catalogService)
    {
        _logger = logger;
        _apiRecipeService = apiRecipeService;
        // this.catalogService = catalogService;
    }

    [HttpGet]
    public async Task<FoodApiResponseCollection?> Get(int count)
    {
        return await _apiRecipeService.GetRandomRecipesAsync(count);
        //catalogService.GetCatalog();
    }
}