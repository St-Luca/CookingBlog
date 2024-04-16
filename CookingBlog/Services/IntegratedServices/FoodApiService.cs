using System.Text.Json;
using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices;

public class FoodApiService : IFoodApiService
{
    private readonly HttpClient _httpClient;

    public FoodApiService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<FoodApiResponseCollection?> GetRandomRecipesAsync(int count)
    {
        var recipes = await _httpClient
            .GetFromJsonAsync<FoodApiResponseCollection>($"recipes/random?apiKey=3747b5cf498f4d8c831a0830ffe8c39c&number={count}");
        return recipes;
    }
}