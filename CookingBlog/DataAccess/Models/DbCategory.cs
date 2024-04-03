using System.ComponentModel.DataAnnotations.Schema;

namespace CookingBlog.DataAccess.Models;

public class DbCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<DbRecipeCategory> Recipes { get; set; } = new();
}
