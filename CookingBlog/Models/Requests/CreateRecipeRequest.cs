using CookingBlog.DataAccess.Models;
using CookingBlog.Models.Core;

namespace CookingBlog.Models.Requests;

public class CreateRecipeRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int UserId { get; set; }
    public int Calories { get; set; }
    public string Image { get; set; } = string.Empty;
    public List<Product> Products { get; set; } = new();
    public List<Category> Categories { get; set; } = new();
}
