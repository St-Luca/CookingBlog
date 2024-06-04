using CookingBlog.Services.IntegratedServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers;
[Route("api/searchRecipes")]
[ApiController]
public class SearchRecipesController: CookingControllerBase
{
    private readonly IFoodApiSearchRecipesService _apiSearchRecipesService;
    public SearchRecipesController(IFoodApiSearchRecipesService apiSearchRecipesService) =>
        _apiSearchRecipesService = apiSearchRecipesService;
    [HttpGet("{query}")]
    public async Task<ActionResult> SearchRecipes(string query)
    {
        return Ok(await _apiSearchRecipesService.SearchRecipesAsync(query));
        //await pro.ChangePassword(Email, request);
        //return Ok();
    }
}