using CookingBlog.Models.Requests;
using CookingBlog.Models.Responses;

namespace CookingBlog.Services.Interfaces;

public interface IRegistrationService
{
    Task<RegisterUserResult> RegisterUser(int userId, RegisterUserRequest registerUserRequest);
    Task Complete(CompleteUserRequest userRequest);
}
