using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
using Microsoft.AspNetCore.Mvc;
namespace CookingBlog.Controllers;

[Route("api/ingredient")]
[ApiController]
public class IngredientsController: CookingControllerBase
{
    private readonly IFoodApiIngredientService _apiIngredientsService;

    public IngredientsController(IFoodApiIngredientService apiIngredientsService) =>
        _apiIngredientsService = apiIngredientsService;
    
    [HttpGet("{recipeId:int}")]
    public async Task<ActionResult> GetIngredientsByRecipeId(int recipeId)
    {
        return Ok(await _apiIngredientsService.GetIngredientsByIdAsync(recipeId));
        //await pro.ChangePassword(Email, request);
        //return Ok();
    } 
}