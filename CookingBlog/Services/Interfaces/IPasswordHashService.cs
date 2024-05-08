namespace CookingBlog.Services.Interfaces;

public interface IPasswordHashService
{
    string HashPassword(string password);
    bool Verify(string password, string hash);
}
