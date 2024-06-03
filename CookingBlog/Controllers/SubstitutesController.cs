using CookingBlog.Services.IntegratedServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookingBlog.Controllers;

[Route("api/substitutes")]
[ApiController]

public class SubstitutesController: CookingControllerBase
{
    private readonly IFoodApiSubstitutesService _apiSubstitutesService;

    public SubstitutesController(IFoodApiSubstitutesService apiSubstitutesService) =>
        _apiSubstitutesService = apiSubstitutesService;
    [HttpGet("{ingredientId:int}")]
    public async Task<ActionResult> GetIngredientSubstitutes(int ingredientId)
    {
        return Ok(await _apiSubstitutesService.GetIngredientSubstitutesAsync(ingredientId));
        //await pro.ChangePassword(Email, request);
        //return Ok();
    }
}