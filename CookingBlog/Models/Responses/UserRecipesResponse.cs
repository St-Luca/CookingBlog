using CookingBlog.Models.Core;

namespace CookingBlog.Models.Responses;

public class UserRecipesResponse
{
    public double RecipesCalories => Recipes.Sum(r => r.Calories);
    public List<Recipe> Recipes { get; set; } = new();
}
