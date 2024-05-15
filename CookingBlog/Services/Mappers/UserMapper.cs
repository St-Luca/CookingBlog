using CookingBlog.DataAccess.Models;
using CookingBlog.Models.Core;
using CookingBlog.Models;
using CookingBlog.Models.Requests;

namespace CookingBlog.Services.Mappers;

public static class UserMapper
{
    public static DbUser Map(this User source)
    {
        var user = new DbUser
        {
            Id = source.Id,
            Name = source.Name,
            Email = source.Email,
            PasswordHash = source.PasswordHash,
            Status = source.Status,
            CreatedDate = source.CreatedDate
        };

        user.Roles = source.Roles.Select(r => r.Map(user)).ToList();

        return user;
    }

    public static User Map(this DbUser source)
    {
        return new User
        {
            Id = source.Id,
            Name = source.Name,
            Email = source.Email,
            PasswordHash = source.PasswordHash,
            Status = source.Status,
            CreatedDate = source.CreatedDate,
            Roles = source.Roles.Select(r => (Role)r.Role).ToList()
        };
    }

    public static DbUser Map(this RegisterUserRequest request, List<Role> roles)
    {
        var user = new User
        {
            //Id = userId,
            Roles = roles,
            Name = request.Name,
            Email = request.Email.Trim(),
            PasswordHash = string.Empty,
            Status = UserStatus.Created,
            CreatedDate = DateTime.UtcNow,
        };

        return user.Map();
    }

    public static DbRole Map(this Role role, DbUser user)
    {
        return new DbRole
        {
            UserId = user.Id,
            User = user,
            Role = (byte)role
        };
    }
}
