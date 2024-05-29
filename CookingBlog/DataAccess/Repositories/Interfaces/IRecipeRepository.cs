using CookingBlog.DataAccess.Models;
using CookingBlog.Models.Core;

namespace CookingBlog.DataAccess.Repositories.Interfaces;

public interface IRecipeRepository
{
    Task Add(DbRecipe recipe);
    List<DbRecipe> GetRecipesByUser(int userId);
}
