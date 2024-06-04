using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices.Interfaces;

public interface IFoodApiIngredientService
{
    Task<FoodApiResponsePriceAndIngredients?> GetIngredientsByIdAsync(int id); 
}