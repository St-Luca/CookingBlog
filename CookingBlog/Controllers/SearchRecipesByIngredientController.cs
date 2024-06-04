using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
using Microsoft.AspNetCore.Mvc;
namespace CookingBlog.Controllers;

[Route("api/searchByIngredients")]
[ApiController]
public class SearchRecipesByIngredientController: CookingControllerBase
{
    private readonly IFoodApiSearchRecipesByIngredients _apiSearchRecipesByIngredientsService;

    public SearchRecipesByIngredientController(IFoodApiSearchRecipesByIngredients apiSearchRecipesByIngredientsService) =>
        _apiSearchRecipesByIngredientsService = apiSearchRecipesByIngredientsService ;
    
    [HttpGet("{ingredients}")]
    public async Task<IActionResult> GetIngredientsByRecipeId(string ingredients)
    {
        return Ok(await _apiSearchRecipesByIngredientsService.SearchRecipesByIngredients(ingredients));
        //await pro.ChangePassword(Email, request);
        //return Ok();
    }   
}