using CookingBlog.Models.Core;

namespace CookingBlog.Models.Responces;

public class AuthResponse
{
    public string AccessToken { get; set; } = null!;
    public RefreshToken RefreshToken { get; set; } = null!;
    public User User { get; set; } = null!;
}
