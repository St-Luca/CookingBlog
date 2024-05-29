using CookingBlog.Models.Core;
using CookingBlog.Models.Requests;
using CookingBlog.Models.Responses;
using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.Interfaces;

public interface IRecipeService
{
    void Add(CreateRecipeRequest createRecipeRequest);
    Task<FoodApiResponseCollection?> GetRandomRecipes(int count);
    UserRecipesResponse GetRecipesByUser(int userId);
}
