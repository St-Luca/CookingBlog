using CookingBlog.Models.Requests;
using CookingBlog.Models.Responces;

namespace CookingBlog.Services.Interfaces;

public interface ITokenGenService
{
    AuthResponse Generate(GenerateTokenRequest generateTokenRequest);
}
