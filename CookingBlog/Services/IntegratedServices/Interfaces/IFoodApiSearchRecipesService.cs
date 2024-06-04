using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices.Interfaces;

public interface IFoodApiSearchRecipesService
{
    Task<FoodApiResponseSearchRecipes?> SearchRecipesAsync(string query);
}