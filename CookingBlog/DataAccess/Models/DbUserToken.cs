using System.ComponentModel.DataAnnotations.Schema;

namespace CookingBlog.DataAccess.Models;

public class DbUserToken
{
    public int UserId { get; set; }
    [ForeignKey("UsertId")]
    public DbUser User { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public DateTime RefreshExpire { get; set; }
    public string AccessToken { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
}
