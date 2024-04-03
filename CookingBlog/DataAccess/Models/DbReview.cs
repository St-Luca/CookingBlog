using System.ComponentModel.DataAnnotations.Schema;

namespace CookingBlog.DataAccess.Models;

public class DbReview
{
    public int Id { get; set; }
    public int UserId { get; set; }
    [ForeignKey("UsertId")]
    public DbUser User { get; set; }
    public int RecipeId { get; set; }
    [ForeignKey("RecipeId")]
    public DbRecipe Recipe { get; set; }
    public string Description { get; set; } = null!;
    public decimal Grade { get; set; }
}
