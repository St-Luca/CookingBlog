using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices;

public class FoodApiIngredientService: IFoodApiIngredientService
{
    private readonly HttpClient _httpClient;

    public FoodApiIngredientService(HttpClient httpClient) => _httpClient = httpClient;
    
    public async Task<FoodApiResponsePriceIngredient?> GetIngredientsByIdAsync(int id)
    {
        var ingredients = await _httpClient
            .GetFromJsonAsync<FoodApiResponsePriceIngredient>(
                $"https://api.spoonacular.com/recipes/{id}/ingredientWidget.json?apiKey=3747b5cf498f4d8c831a0830ffe8c39c&");
        ingredients.Image = $"https://img.spoonacular.com/ingredients_250x250/{ingredients.Image}";
        return ingredients;
    }
}