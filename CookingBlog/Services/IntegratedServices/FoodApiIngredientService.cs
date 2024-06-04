using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices;

public class FoodApiIngredientService: IFoodApiIngredientService
{
    private readonly HttpClient _httpClient;

    public FoodApiIngredientService(HttpClient httpClient) => _httpClient = httpClient;
    
    public async Task<FoodApiResponsePriceAndIngredients?> GetIngredientsByIdAsync(int id)
    {
        var ingredientsAndPrices = await _httpClient
            .GetFromJsonAsync<FoodApiResponsePriceAndIngredients>(
                $"https://api.spoonacular.com/recipes/{id}/ingredientWidget.json?apiKey=3747b5cf498f4d8c831a0830ffe8c39c&");
        var ingredients = ingredientsAndPrices.Ingredients;
        for (var i = 0; i < ingredients.Count; i++)
        {
            ingredients[i].Image = $"https://img.spoonacular.com/ingredients_250x250/{ingredients[i].Image}";
        }
        return ingredientsAndPrices;
    }
}