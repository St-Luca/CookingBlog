namespace CookingBlog.Models;

public class UserToken
{
    public int UserId { get; set; }
    public string RefreshToken { get; set; } = null!;
    public DateTime RefreshExpire { get; set; }
    public string AccessToken { get; set; } = null!;
    public DateTime CreatedDate { get; set; }

    public bool IsExpired()
    {
        return DateTime.Now > RefreshExpire;
    }
}
