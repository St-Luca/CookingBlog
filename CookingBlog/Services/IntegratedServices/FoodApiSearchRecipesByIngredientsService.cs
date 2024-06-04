using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices;

public class FoodApiSearchRecipesByIngredientsService: IFoodApiSearchRecipesByIngredients
{
    private readonly HttpClient _httpClient;

    public FoodApiSearchRecipesByIngredientsService(HttpClient httpClient) => _httpClient = httpClient;
    
    public async Task<List<FoodApiSearchRecipesByIngredientsService>?> SearchRecipesByIngredients(string[] ingredients)
    {
        var recipes = new List<FoodApiSearchRecipesByIngredientsService>();
        for(var i = 0; i < ingredients.Length; i++)
        {
            /*recipes = await _httpClient
                .GetFromJsonAsync List<FoodApiResponseSearchByIngredients>(
                    $"");*/
        }
        return recipes;
    }
}