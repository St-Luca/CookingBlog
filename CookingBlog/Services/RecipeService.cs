using CookingBlog.DataAccess.Repositories;
using CookingBlog.DataAccess.Repositories.Interfaces;
using CookingBlog.Models.Core;
using CookingBlog.Models.Requests;
using CookingBlog.Models.Responses;
using CookingBlog.Services.IntegratedServices.Interfaces;
using CookingBlog.Services.IntegratedServices.Responses;
using CookingBlog.Services.Interfaces;
using CookingBlog.Services.Mappers;
using System.Linq;

namespace CookingBlog.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository recipeRepository;
    private readonly IFoodApiRecipeService foodApiService;

    public RecipeService(IRecipeRepository recipeRepository, IFoodApiRecipeService foodApiService)
    {
        this.recipeRepository = recipeRepository;
        this.foodApiService = foodApiService;
    }

    public async void Add(CreateRecipeRequest recipeRequest)
    {
        await recipeRepository.Add(recipeRequest.Map());
    }

    public async Task<FoodApiResponseCollection?> GetRandomRecipes(int count, int userId)
    {
        var recipes = await foodApiService.GetRandomRecipesAsync(count);

        if (recipes != null)
        {
            recipeRepository.Add(recipes.Recipes.Map(userId));
        }

        return recipes;
    }

    public UserRecipesResponse GetRecipesByUser(int userId)
    {
        var dbRecipes = recipeRepository.GetRecipesByUser(userId);

        return new UserRecipesResponse
        {
            Recipes = dbRecipes.Map()
        };
    }
}
