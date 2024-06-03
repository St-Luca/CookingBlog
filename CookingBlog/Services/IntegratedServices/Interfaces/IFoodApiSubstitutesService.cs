using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices.Interfaces;

public interface IFoodApiSubstitutesService
{
    Task<FoodApiResponseIngredientSubstitutes?> GetIngredientSubstitutesAsync(int id);
}