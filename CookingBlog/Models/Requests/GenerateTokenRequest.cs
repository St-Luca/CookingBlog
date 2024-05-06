namespace CookingBlog.Models.Requests;

public class GenerateTokenRequest
{
    public string UserEmail { get; set; } = null!;
    public int UserId { get; set; }
    public bool IsModerator { get; set; }
}
