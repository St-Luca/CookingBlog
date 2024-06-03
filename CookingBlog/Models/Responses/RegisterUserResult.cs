namespace CookingBlog.Models.Responses;

public class RegisterUserResult
{
    public string Email { get; set; } = null!;
    public RegisterStatus Status { get; set; }
}
