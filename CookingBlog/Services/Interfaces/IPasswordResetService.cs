using CookingBlog.Models.Requests;

namespace CookingBlog.Services.Interfaces;

public interface IPasswordResetService
{
    Task RestorePassword(RestorePasswordRequest request);
    Task ResetPassword(ResetPasswordRequest request);
}
