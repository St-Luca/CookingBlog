using CookingBlog.DataAccess.Models;
using CookingBlog.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CookingBlog.DataAccess.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly CookingContext context;

    public RecipeRepository(CookingContext dbContext)
    {
        context = dbContext;
    }

    public async Task Add(DbRecipe recipe)
    {
        await context.Recipes.AddAsync(recipe);
        context.SaveChanges();
    }

    public List<DbRecipe> GetRecipesByUser(int userId)
    {
        return context.Recipes.Include(l => l.Products).Include(u => u.Categories).Include(u => u.Reviews).Where(o => o.UserId.Equals(userId)).ToList();
    }
}
