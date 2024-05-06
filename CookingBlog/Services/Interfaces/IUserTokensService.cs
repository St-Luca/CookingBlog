using CookingBlog.Models;

namespace CookingBlog.Services.Interfaces;

public interface IUserTokensService
{
    Task<UserToken?> Get(int userId, string refreshToken);
    Task<UserToken?> Get(string refreshToken);
    Task<UserToken> Add(UserToken userToken);
}
