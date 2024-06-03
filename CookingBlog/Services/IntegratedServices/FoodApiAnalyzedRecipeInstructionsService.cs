using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices;

public class FoodApiAnalyzedRecipeInstructionsService: IFoodApiAnalyzedRecipeInstructionsService
{
    private readonly HttpClient _httpClient;

    public FoodApiAnalyzedRecipeInstructionsService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<FoodApiResponseInstructions?> GetInstructionsByIdAsync(int id)
    {
        var instructions = await _httpClient
            .GetFromJsonAsync<FoodApiResponseInstructions>(
                $"https://api.spoonacular.com/recipes/{id}/equipmentWidget.json?apiKey=3747b5cf498f4d8c831a0830ffe8c39c&");
        var steps = instructions.Steps;
        for (int i = 0; i < steps.Count; i++)
        {
            var equipments = steps[i].Equipment;
            var ingredients = steps[i].Ingredients;
            for (int j = 0; i < equipments.Count; j++)
            {
                equipments[j].Image =  $"https://img.spoonacular.com/equipment_250x250/{equipments[i].Image}";
            }
            
            for (int j = 0; i < ingredients.Count; j++)
            {
                ingredients[j].Image =  $"https://img.spoonacular.com/ingredients_250x250/{ingredients[i].Image}";
            }
        }
        return instructions;
    }
}