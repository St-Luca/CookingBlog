using System.Net;
using System.Text.Json;
using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
using Newtonsoft.Json;

namespace CookingBlog.Services.IntegratedServices;

public class FoodApiRecipeService : IFoodApiRecipeService
{
    private readonly HttpClient _httpClient;

    public FoodApiRecipeService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<FoodApiResponseCollection?> GetRandomRecipesAsync(int count)
    {
        var recipes = await _httpClient
            .GetFromJsonAsync<FoodApiResponseCollection>($"recipes/random?apiKey=3747b5cf498f4d8c831a0830ffe8c39c&number={count}");
        var listOfRecipes = recipes?.Recipes;

        for (int i = 0; i < listOfRecipes?.Count; i++)
        {
            var prevPrice = listOfRecipes[i].PricePerServing; 
            listOfRecipes[i].PricePerServing = prevPrice * 0.01 * 91.36;
            var listOfIngredients = listOfRecipes[i].ExtendedIngredients;
            foreach (var element in listOfIngredients)
            {
                string prevImageOfIngredient = element.Image;
                element.Image = $"https://img.spoonacular.com/ingredients_250x250/{prevImageOfIngredient}";
            }
        }
        return recipes;
    }
}