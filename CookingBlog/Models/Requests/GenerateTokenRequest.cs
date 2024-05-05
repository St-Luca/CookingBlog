namespace CookingBlog.Models.Requests;

public class GenerateTokenRequest
{
    public string UserEmail { get; set; } = null!;
    public Guid UserId { get; set; }
    public bool IsModerator { get; set; }
    public int AccountId { get; set; }
}
