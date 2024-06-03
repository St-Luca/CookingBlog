using CookingBlog.Models;

namespace CookingBlog.DataAccess.Models;

public class DbUser
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Picture { get; set; } = string.Empty;
    public UserStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public string PasswordHash { get; set; } = null!;
    public string Email { get; set; } = null!;
    public decimal Raiting { get; set; }
    public List<DbReview> Reviews { get; set; } = new();
    public List<DbRecipe> Recipes { get; set; } = new();
    public List<DbRole> Roles { get; set; } = new();
    public List<DbUserToken> Tokens { get; set; } = new();

}
