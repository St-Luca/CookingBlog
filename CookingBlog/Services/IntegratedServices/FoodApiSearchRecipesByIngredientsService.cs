using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices;

public class FoodApiSearchRecipesByIngredientsService: IFoodApiSearchRecipesByIngredients
{
    private readonly HttpClient _httpClient;

    public FoodApiSearchRecipesByIngredientsService(HttpClient httpClient) => _httpClient = httpClient;
    
    public async Task<List<FoodApiResponseSearchByIngredients>?> SearchRecipesByIngredients(string ingredients)
    {
        string[] ingredientsArray = ingredients.Split(" ");
        var recipes = new List<FoodApiResponseSearchByIngredients>();
        for(var i = 1; i < ingredientsArray.Length; i++)
        {
            ingredientsArray[i] = ",+" + ingredientsArray[i];
        }
        string result = string.Join("", ingredientsArray);
        recipes = await _httpClient
            .GetFromJsonAsync <List<FoodApiResponseSearchByIngredients>?>(
                $"https://api.spoonacular.com/recipes/findByIngredients?ingredients={result}&apiKey=6de32bcb4b014c519b63babb12c164e7&");
        return recipes;
    }
}