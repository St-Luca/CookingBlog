using System.ComponentModel.DataAnnotations.Schema;

namespace CookingBlog.DataAccess.Models;

public class DbRecipeCategory
{
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public DbCategory Category { get; set; } = null!;
    public int RecipeId { get; set; }

    [ForeignKey("RecipeId")]
    public DbRecipe Recipe { get; set; } = null!;
}
