using CookingBlog.Services.IntegratedServices.Responses;
using CookingBlog.Services.IntegratedServices.Interfaces;
namespace CookingBlog.Services.IntegratedServices;

public class FoodApiPriceAndIngredientService: IFoodApiPriceAndIngredientService
{
    private readonly HttpClient _httpClient;

    public FoodApiPriceAndIngredientService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<FoodApiResponsePriceAndIngredients?> GetListOfIngredientsAsync(int id)
    {
        var ingredientsAndPrice = await _httpClient
            .GetFromJsonAsync<FoodApiResponsePriceAndIngredients>($"https://api.spoonacular.com/recipes/{id}/priceBreakdownWidget.json?apiKey=3747b5cf498f4d8c831a0830ffe8c39c&");
        var ingredients = ingredientsAndPrice.Ingredients;
        for (int i = 0; i < ingredients.Count; i++)
        {
            ingredients[i].Image = $"https://img.spoonacular.com/ingredients_250x250/{ingredients[i].Image}";
            ingredients[i].Price *= 0.01 * 88.69;
        }
        
        ingredientsAndPrice.TotalCost = ingredients.Sum(i => i.Price);
        ingredientsAndPrice.TotalCostPerServing *= 0.01 * 88.69;
        return ingredientsAndPrice;
    }
}