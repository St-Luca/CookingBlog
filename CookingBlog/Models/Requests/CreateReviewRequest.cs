namespace CookingBlog.Models.Requests;

public class CreateReviewRequest
{
    public int UserId { get; set; }
    public int RecipeId { get; set; }
    public string Description { get; set; } = null!;
    public decimal Grade { get; set; }
}
