using CookingBlog.Models;
using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers;

[ApiController]
[Route("api/catalog")]
public class RecipeController : ControllerBase
{
    private readonly ILogger<RecipeController> _logger;

    private readonly IFoodApiService _apiService;
    //private readonly ICatalogService catalogService;

    public RecipeController(ILogger<RecipeController> logger, IFoodApiService apiService)//, ICatalogService catalogService)
    {
        _logger = logger;
        _apiService = apiService;
        // this.catalogService = catalogService;
    }

    [HttpGet]
    public async Task<FoodApiResponseCollection?> Get(int count)
    {
        return await _apiService.GetRandomRecipesAsync(count);
        //catalogService.GetCatalog();
    }
}