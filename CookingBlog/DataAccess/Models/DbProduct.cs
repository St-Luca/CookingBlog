namespace CookingBlog.DataAccess.Models;

public class DbProduct
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<DbRecipeProduct> Recipes { get; set; } = new();
}
