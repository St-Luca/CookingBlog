using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices;

public class FoodApiAnalyzedRecipeInstructionsService : IFoodApiAnalyzedRecipeInstructionsService
{
    private readonly HttpClient _httpClient;

    public FoodApiAnalyzedRecipeInstructionsService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<List<FoodApiResponseInstructions>?> GetInstructionsByIdAsync(int id)
    {
        var instructions = await _httpClient
            .GetFromJsonAsync<List<FoodApiResponseInstructions>>(
                $"https://api.spoonacular.com/recipes/{id}/analyzedInstructions?apiKey=3747b5cf498f4d8c831a0830ffe8c39c&");

        if (instructions == null) return new List<FoodApiResponseInstructions>();
        
        instructions.ForEach(instruction =>
        {
            var steps = instruction.Steps;
            for (var i = 0; i < steps.Count; i++)
            {
                var equipments = steps[i].Equipment;
                var ingredients = steps[i].Ingredients;
                foreach (var t in equipments)
                {
                    t.Image = $"https://img.spoonacular.com/equipment_250x250/{t.Image}";
                }

                foreach (var t in ingredients)
                {
                    t.Image =
                        $"https://img.spoonacular.com/ingredients_250x250/{t.Image}";
                }
            }
        });
        
        return instructions;
    }
}