using CookingBlog.Models.Core;

namespace CookingBlog.Models.Requests;

public class CreateUserRequest
{
    public string Email { get; set; } = null!;
    public Role Role { get; set; }
}
