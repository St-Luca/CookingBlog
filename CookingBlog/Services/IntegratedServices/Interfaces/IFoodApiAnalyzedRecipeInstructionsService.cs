using CookingBlog.Services.IntegratedServices.Responses;

namespace CookingBlog.Services.IntegratedServices.Interfaces;

public interface IFoodApiAnalyzedRecipeInstructionsService
{
    Task<List<FoodApiResponseInstructions>?> GetInstructionsByIdAsync(int id);
}