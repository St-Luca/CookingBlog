using CookingBlog.Models.Core;
using CookingBlog.Models.Requests;

namespace CookingBlog.Services.Interfaces;

public interface IUserService
{
    Task<User?> GetById(int id);
    Task<User?> GetByEmail(string email);
    Task<User?> GetUser(string email, string password);
    Task ChangePassword(ChangePasswordRequest request);
}
