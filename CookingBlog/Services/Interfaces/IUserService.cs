using CookingBlog.Models.Core;
using CookingBlog.Models.Requests;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace CookingBlog.Services.Interfaces;

public interface IUserService
{
    Task<User?> GetById(int id);
    Task<User?> GetByEmail(string email);
    Task<User?> GetUser(string email, string password);
    Task ChangePassword(string email, ChangePasswordRequest request);
    Task Add(User user, IDbContextTransaction transaction);
    Task Update(User user, IDbContextTransaction transaction);
    Task Update(User user);
    Task<IDbContextTransaction> BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
}
