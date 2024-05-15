namespace CookingBlog.Models.Requests;

public class CompleteUserRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Token { get; set; } = null!;
}
