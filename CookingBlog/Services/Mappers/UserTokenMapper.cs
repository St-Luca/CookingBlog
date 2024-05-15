using CookingBlog.DataAccess.Models;
using CookingBlog.Models;

namespace CookingBlog.Services.Mappers;

public static class UserTokenMapper
{
    public static UserToken Map(this DbUserToken source)
    {
        return new UserToken
        {
            UserId = source.UserId,
            RefreshToken = source.RefreshToken,
            AccessToken = source.AccessToken,
            CreatedDate = source.CreatedDate,
            RefreshExpire = source.RefreshExpire
        };
    }

    public static DbUserToken Map(this UserToken source)
    {
        return new DbUserToken
        {
            UserId = source.UserId,
            RefreshToken = source.RefreshToken,
            AccessToken = source.AccessToken,
            CreatedDate = source.CreatedDate,
            RefreshExpire = source.RefreshExpire
        };
    }
}
