using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices;

public class FoodApiSearchRecipesService: IFoodApiSearchRecipesService
{
    private readonly HttpClient _httpClient;

    public FoodApiSearchRecipesService(HttpClient httpClient) => _httpClient = httpClient;
    
    public async Task<FoodApiResponseSearchRecipes?> SearchRecipesAsync(string query)
    {
        var recipes = await _httpClient
            .GetFromJsonAsync<FoodApiResponseSearchRecipes>(
                $"https://api.spoonacular.com/recipes/complexSearch?query={query}&apiKey=3747b5cf498f4d8c831a0830ffe8c39c&");
        return recipes;
    }
}