using CookingBlog.DataAccess.Repositories.Interfaces;
using CookingBlog.Models.Core;
using CookingBlog.Models.Requests;
using CookingBlog.Services.Interfaces;
using System.Net;

namespace CookingBlog.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IPasswordHashService passwordHashService;

    public UserService(IUserRepository userRepository, IPasswordHashService passwordHashService)
    {
        this.userRepository = userRepository;
        this.passwordHashService = passwordHashService;
    }

    public async Task<User?> GetById(int id)
    {
        //var dbUser = userRepository.GetById(id);

        //if (dbUser is null)
        //{
        //    return default;
        //}

        //return dbUser.Map();
        return new User();
    }

    public async Task<User?> GetByEmail(string email)
    {
        //var dbUser = userRepository.GetByEmail(email);

        //if (dbUser is null)
        //{
        //    return default;
        //}

        //return dbUser.Map();
        return new User();
    }

    public async Task<User?> GetUser(string email, string password)
    {
        var user = await GetByEmail(email);

        if (user is null)
        {
            return default;
        }

        if (user.PasswordHash is null)
        {
            throw new HttpRequestException($"user {email} has not set a password yet");
        }

        if (!passwordHashService.Verify(password, user.PasswordHash))
        {
            throw new HttpRequestException("email or password is incorrect", new Exception(), HttpStatusCode.Forbidden);
        }

        return user;
    }

    public async Task<User> Add(RegisterUserRequest userRequest)
    {
        var existUser = await GetByEmail(userRequest.Email);

        if (existUser != null)
        {
            throw new HttpRequestException($"user {userRequest.Email} is already exists");
        }

        //var dbUser = await userRepository.Add(userRequest.Map());

        //var role = await userRolesService.Add(new Role
        //{
        //    UserId = dbUser.Id,
        //    Role = userRequest.UserRole
        //});

        //return dbUser.Map();
        return new User();
    }

    public async Task<User> Update(User user)
    {
        //var dbUser = await userRepository.Update(user.Map());

        //return dbUser.Map();
        return new User();
    }

    public async Task ChangePassword(ChangePasswordRequest request)
    {
        var user = await GetUser(request.Email, request.OldPassword);

        if (user is null)
        {
            throw new HttpRequestException($"user {request.Email} does not exist");
        }

        user.PasswordHash = passwordHashService.HashPassword(request.NewPassword);
        await Update(user);
    }
}
