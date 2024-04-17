namespace CookingBlog.Models;

public class Review
{
    public int Id { get; set; }
    public User User { get; set; } = null!;
    public Recipe Recipe { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Grade { get; set; }
}
