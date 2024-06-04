using CookingBlog.DataAccess.Models;
using CookingBlog.Models.Core;
using CookingBlog.Models.Requests;
using System.Linq;

namespace CookingBlog.Services.Mappers;

public static class RecipeMapper
{

    public static DbRecipe Map(this CreateRecipeRequest request)
    {
        return new DbRecipe
        {
            Name = request.Name,
            Description = request.Description,
            Calories = request.Calories,
            UserId = request.UserId,
            Image = request.Image,
            //Products = request.Products.Map(),
            //Categories = request.Categories.Map(),
        };
    }

    public static List<Recipe> Map(this List<DbRecipe> source)
    {
        return source.Select(r => r.Map()).ToList();
    }
    
    public static Recipe Map(this DbRecipe source)
    {
        return new Recipe
        {
            Name = source.Name,
            Description = source.Description,
            Calories = source.Calories,
            UserId = source.UserId,
            Image = source.Image,
            //Products = request.Products.Map(),
            //Categories = request.Categories.Map(),
        };
    }

}
