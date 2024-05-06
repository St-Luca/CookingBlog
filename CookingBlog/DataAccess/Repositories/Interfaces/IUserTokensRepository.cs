using CookingBlog.DataAccess.Models;

namespace CookingBlog.DataAccess.Repositories.Interfaces;

public interface IUserTokensRepository
{
    Task<DbUserToken?> Get(int userId, string refreshToken);
    Task<DbUserToken?> Get(string refreshToken);
    Task<DbUserToken> Add(DbUserToken userToken);
}
