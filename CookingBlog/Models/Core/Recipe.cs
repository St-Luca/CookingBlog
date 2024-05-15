using CookingBlog.DataAccess.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingBlog.Models.Core;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DbUser User { get; set; } = null!;
    public int Calories { get; set; }
    public string Picture { get; set; } = string.Empty;
    public List<Product> Products { get; set; } = new();
    public List<Category> Categories { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
}