using System.ComponentModel.DataAnnotations.Schema;

namespace CookingBlog.DataAccess.Models;

public class DbRecipe
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int UserId { get; set; }
    [ForeignKey("UsertId")]
    public DbUser User { get; set; } = null!;
    public int Calories { get; set; }
    public string Picture { get; set;} = string.Empty;
    public List<DbRecipeProduct> Products { get; set; } = new();
    public List<DbRecipeCategory> Categories { get; set; } = new();
    public List<DbReview> Reviews { get; set; } = new();

}
