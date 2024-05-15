using CookingBlog.DataAccess.Repositories.Interfaces;
using CookingBlog.Models;
using CookingBlog.Services.Interfaces;
using CookingBlog.Services.Mappers;

namespace CookingBlog.Services;

public class UserTokensService : IUserTokensService
{
    private readonly IUserTokensRepository userTokensRepository;

    public UserTokensService(IUserTokensRepository userTokensRepository)
    {
        this.userTokensRepository = userTokensRepository;
    }

    public async Task<UserToken?> Get(int userId, string refreshToken)
    {
        var result = await userTokensRepository.Get(userId, refreshToken);

        return result?.Map();
    }

    public async Task<UserToken?> Get(string refreshToken)
    {
        var result = await userTokensRepository.Get(refreshToken);

        return result?.Map();
    }

    public async Task<UserToken> Add(UserToken userToken)
    {
        var result = await userTokensRepository.Add(userToken.Map());

        return result.Map();
    }
}
