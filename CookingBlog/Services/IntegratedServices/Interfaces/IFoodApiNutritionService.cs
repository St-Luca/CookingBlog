using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices.Interfaces;

public interface IFoodApiNutritionService
{
    Task<FoodApiResponseNutrition?> GetNutritionsByIdAsync(int id);
}