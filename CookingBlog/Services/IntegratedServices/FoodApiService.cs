using System.Net;
using System.Text.Json;
using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
using Newtonsoft.Json;

namespace CookingBlog.Services.IntegratedServices;

public class FoodApiService : IFoodApiService
{
    private readonly HttpClient _httpClient;

    public FoodApiService(HttpClient httpClient) => _httpClient = httpClient;

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

    public List<FoodApiResponseIngredient?> GetListOfIngredients(FoodApiResponseCollection recipe)
    {
        var informationAboutRecipe = recipe?.Recipes;
        List<FoodApiResponseIngredient> listOfIngredients = new List<FoodApiResponseIngredient>();
        for (int i = 0; i < informationAboutRecipe?.Count; i++)
        {
            var ingredients = informationAboutRecipe[i].ExtendedIngredients;
            for (int j = 1; j < ingredients.Count; j++)
            {
                ingredients[j].Price = informationAboutRecipe[i].PricePerServing * 0.01 * 91.36;
                string prevImageOfIngredient = ingredients[j].Image;
                ingredients[j].Image = $"https://img.spoonacular.com/ingredients_250x250/{prevImageOfIngredient}";
                listOfIngredients?.Add(ingredients[i]);
            }
        }
        return listOfIngredients;
    }
}