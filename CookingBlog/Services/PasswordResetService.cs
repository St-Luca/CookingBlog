using CookingBlog.Models.Requests;
using CookingBlog.Services.Interfaces;

namespace CookingBlog.Services;

public class PasswordResetService : IPasswordResetService
{
    public Task ResetPassword(ResetPasswordRequest request)
    {
        throw new NotImplementedException();
    }

    public Task RestorePassword(RestorePasswordRequest request)
    {
        throw new NotImplementedException();
    }
}
