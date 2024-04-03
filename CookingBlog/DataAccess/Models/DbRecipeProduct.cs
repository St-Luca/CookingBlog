using System.ComponentModel.DataAnnotations.Schema;

namespace CookingBlog.DataAccess.Models;

public class DbRecipeProduct
{
    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public DbProduct Product { get; set; } = null!;
    public int RecipeId { get; set; }

    [ForeignKey("RecipeId")]
    public DbRecipe Recipe { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Picture { get; set; } = null!;
}
