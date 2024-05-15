using CookingBlog.DataAccess.Models;
using CookingBlog.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace CookingBlog.DataAccess.Repositories.Interfaces;

public interface IUserRepository
{
    Task<DbUser> Add(DbUser user);
    Task Add(DbUser user, IDbContextTransaction cookingTransaction);
    Task Update(DbUser user);
    Task Update(DbUser user, IDbContextTransaction cookingTransaction);
    DbUser? GetById(int id);
    DbUser? GetByEmail(string email);
    Task<IDbContextTransaction> BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
}
