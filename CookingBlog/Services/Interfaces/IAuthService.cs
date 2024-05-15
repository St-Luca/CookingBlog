using CookingBlog.Models.Requests;
using CookingBlog.Models.Responces;

namespace CookingBlog.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResponse?> Authorization(AuthorizationRequest loginRequest);
    Task<AuthResponse> Refresh(RefreshRequest refreshRequest);
}
