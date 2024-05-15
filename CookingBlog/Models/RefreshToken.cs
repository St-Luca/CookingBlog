namespace CookingBlog.Models;

public class RefreshToken
{
    public DateTime Expires { get; set; }
    public string Token { get; set; } = null!;
}
