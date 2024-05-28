using CookingBlog.Models.Requests;
using CookingBlog.Services;
using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController : CookingControllerBase
{
    private readonly IFoodApiPriceAndIngredientService _apiPriceAndIngredientService;

    public ProductController(IFoodApiPriceAndIngredientService apiPriceAndIngredientService) =>
        _apiPriceAndIngredientService = apiPriceAndIngredientService;
    
    [HttpGet("{recipeId:int}")]
    public async Task<ActionResult> GetProductsByRecipeId(int recipeId)
    {
        return Ok(await _apiPriceAndIngredientService.GetListOfIngredientsAsync(recipeId));
        //await pro.ChangePassword(Email, request);
        //return Ok();
    }
}
