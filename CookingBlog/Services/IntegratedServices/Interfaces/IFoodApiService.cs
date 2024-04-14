using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices.Interfaces;

public interface IFoodApiService
{
    Task<FoodApiResponseCollection?> GetRandomRecipesAsync(int count);
}