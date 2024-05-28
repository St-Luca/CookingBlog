using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
using Microsoft.AspNetCore.Mvc;
namespace CookingBlog.Controllers;

[Route("api/taste")]
[ApiController]
public class TasteController: CookingControllerBase
{
    private readonly IFoodApiTasteService _apiTasteService;

    public TasteController(IFoodApiTasteService apiTasteService) =>
        _apiTasteService = apiTasteService;
    
    [HttpGet("{recipeId:int}")]
    public async Task<ActionResult> GetProductsByRecipeId(int recipeId)
    {
        return Ok(await _apiTasteService.GetTasteByIdAsync(recipeId));
        //await pro.ChangePassword(Email, request);
        //return Ok();
    }
}