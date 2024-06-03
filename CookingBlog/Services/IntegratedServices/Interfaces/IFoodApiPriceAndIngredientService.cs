using CookingBlog.Services.IntegratedServices.Responses;


namespace CookingBlog.Services.IntegratedServices.Interfaces;

public interface IFoodApiPriceAndIngredientService
{
    Task<FoodApiResponsePriceAndIngredients?> GetListOfIngredientsAsync(int count);
}