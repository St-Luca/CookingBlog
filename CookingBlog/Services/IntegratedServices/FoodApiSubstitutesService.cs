using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices;

public class FoodApiSubstitutesService: IFoodApiSubstitutesService
{
    private readonly HttpClient _httpClient;

    public FoodApiSubstitutesService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<FoodApiResponseIngredientSubstitutes?> GetIngredientSubstitutesAsync(int id)
    {
        var substitutes = await _httpClient
            .GetFromJsonAsync<FoodApiResponseIngredientSubstitutes>(
                $"https://api.spoonacular.com/food/ingredients/{id}/substitutes?apiKey=3747b5cf498f4d8c831a0830ffe8c39c&");
        return substitutes;
    }
}