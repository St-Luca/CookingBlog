using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices.Interfaces;

public interface IFoodApiSearchRecipesByIngredients
{
    public Task<List<FoodApiSearchRecipesByIngredientsService>?> SearchRecipesByIngredients(string[] ingredients);
}