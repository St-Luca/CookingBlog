using System.ComponentModel.DataAnnotations.Schema;

namespace CookingBlog.DataAccess.Models;

public class DbRole
{
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public DbUser User { get; set; } = null!;
    public int Role { get; set; }
}
