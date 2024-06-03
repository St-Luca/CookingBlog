using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
using Microsoft.AspNetCore.Mvc;
namespace CookingBlog.Controllers;

public class NutritionContoller: CookingControllerBase
{
    [Route("api/nutrition")]
    [ApiController]
    public class NutritionController : CookingControllerBase
    {
        private readonly IFoodApiNutritionService _apiNutritionsService;

        public NutritionController(IFoodApiNutritionService apiNutritionsService) =>
            _apiNutritionsService = apiNutritionsService;

        [HttpGet("{recipeId:int}")]
        public async Task<ActionResult> GetNutrionsByRecipeId(int recipeId)
        {
            return Ok(await _apiNutritionsService.GetNutritionsByIdAsync(recipeId));
            //await pro.ChangePassword(Email, request);
            //return Ok();
        }
    }
}