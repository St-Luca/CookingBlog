using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
using Microsoft.AspNetCore.Mvc;
namespace CookingBlog.Controllers;

[Route("api/equipment")]
[ApiController]
public class EquipmentController: CookingControllerBase
{
    private readonly IFoodApiEquipmentService _apiEquipmentService;

    public EquipmentController(IFoodApiEquipmentService apiEquipmentService) =>
        _apiEquipmentService = apiEquipmentService;
    
    [HttpGet("{recipeId:int}")]
    public async Task<ActionResult> GetEquipmentsByRecipeId(int recipeId)
    {
        return Ok(await _apiEquipmentService.GetEquipmentsByIdAsync(recipeId));
        //await pro.ChangePassword(Email, request);
        //return Ok();
    }
}