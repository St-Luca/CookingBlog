using CookingBlog.Models;
using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers;

[ApiController]
[Route("catalog")]
public class CatalogController : ControllerBase
{
    private readonly ILogger<CatalogController> _logger;

    private readonly IFoodApiService _apiService;
    //private readonly ICatalogService catalogService;

    public CatalogController(ILogger<CatalogController> logger, IFoodApiService apiService)//, ICatalogService catalogService)
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