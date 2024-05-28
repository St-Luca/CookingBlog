using CookingBlog.Models;
using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers
{
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
            var recipes = await _apiService.GetRandomRecipesAsync(count);
            _apiService.GetListOfIngredients(recipes);
            return recipes;
            //catalogService.GetCatalog();
            // return Enumerable.Range(1, 5).Select(index => new Recipe
            // {
            //     Id = Random.Shared.Next(1, 55),
            //     Name = "Recipe" + Random.Shared.Next(1, 55)
            // })
            // .ToArray();
        }
    }
}