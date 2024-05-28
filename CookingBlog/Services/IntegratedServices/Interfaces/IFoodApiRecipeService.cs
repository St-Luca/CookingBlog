using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices.Interfaces;

public interface IFoodApiRecipeService
{
    Task<FoodApiResponseCollection?> GetRandomRecipesAsync(int count);
}