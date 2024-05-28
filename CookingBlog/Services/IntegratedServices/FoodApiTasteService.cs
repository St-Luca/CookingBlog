using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
namespace CookingBlog.Services.IntegratedServices;

public class FoodApiTasteService: IFoodApiTasteService
{
    private readonly HttpClient _httpClient;

    public FoodApiTasteService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<FoodApiResponseTaste?> GetTasteByIdAsync(int id)
    {
        var taste = await _httpClient
            .GetFromJsonAsync<FoodApiResponseTaste>(
                $"https://api.spoonacular.com/recipes/{id}/tasteWidget.json?apiKey=3747b5cf498f4d8c831a0830ffe8c39c&");
        return taste;
    }
}