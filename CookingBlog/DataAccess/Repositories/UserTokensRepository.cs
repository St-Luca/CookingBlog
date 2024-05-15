using CookingBlog.DataAccess.Models;
using CookingBlog.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CookingBlog.DataAccess.Repositories;

public class UserTokensRepository : IUserTokensRepository
{
    private readonly CookingContext context;

    public UserTokensRepository(CookingContext context)
    {
        this.context = context;
    }

    public async Task<DbUserToken?> Get(int userId, string refreshToken)
    {
        return await context.UserTokens.FirstOrDefaultAsync(t => t.RefreshToken.Equals(refreshToken) && t.UserId == userId);
    }

    public async Task<DbUserToken?> Get(string refreshToken)
    {
        return await context.UserTokens.FirstOrDefaultAsync(t => t.RefreshToken.Equals(refreshToken));
    }

    public async Task<DbUserToken> Add(DbUserToken userToken)
    {
        await context.UserTokens.AddAsync(userToken);

        return userToken;
    }
}
