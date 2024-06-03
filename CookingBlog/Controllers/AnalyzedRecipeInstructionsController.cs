using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
using Microsoft.AspNetCore.Mvc;
namespace CookingBlog.Controllers;

[Route("api/instructions")]
[ApiController]
public class AnalyzedRecipeInstructionsController: CookingControllerBase
{
    private readonly IFoodApiAnalyzedRecipeInstructionsService _apiIntstructionsService;

    public AnalyzedRecipeInstructionsController(IFoodApiAnalyzedRecipeInstructionsService apiIntstructionsService) =>
        _apiIntstructionsService = apiIntstructionsService;
    
    [HttpGet("{recipeId:int}")]
    public async Task<ActionResult> GetInstructionsById(int recipeId)
    {
        return Ok(await _apiIntstructionsService.GetInstructionsByIdAsync(recipeId));
        //await pro.ChangePassword(Email, request);
        //return Ok();
    } 
}