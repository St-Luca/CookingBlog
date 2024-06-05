using CookingBlog.DataAccess.Models;

namespace CookingBlog.DataAccess.Repositories.Interfaces;

public interface IRecipeRepository
{
    Task Add(DbRecipe recipe);
    void Add(List<DbRecipe> recipes);
    List<DbRecipe> GetRecipesByUser(int userId);
}
