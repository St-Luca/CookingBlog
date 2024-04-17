using CookingBlog.Services.Interfaces;

namespace CookingBlog.Services;

public class PasswordHashService : IPasswordHashService
{
    public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
    public bool Verify(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);
}
