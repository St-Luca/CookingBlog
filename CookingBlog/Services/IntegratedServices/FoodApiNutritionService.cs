using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
namespace CookingBlog.Services.IntegratedServices;

public class FoodApiNutritionService: IFoodApiNutritionService
{
    private readonly HttpClient _httpClient;

    public FoodApiNutritionService(HttpClient httpClient) => _httpClient = httpClient;
    
    public async Task<FoodApiResponseNutrition?> GetNutritionsByIdAsync(int id)
    {
        var nutritions = await _httpClient
            .GetFromJsonAsync<FoodApiResponseNutrition>(
                $"https://api.spoonacular.com/recipes/{id}/nutritionWidget.json?apiKey=3747b5cf498f4d8c831a0830ffe8c39c&");
        return nutritions;
    }
}