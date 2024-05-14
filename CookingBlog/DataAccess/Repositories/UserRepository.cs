using CookingBlog.DataAccess.Models;
using CookingBlog.DataAccess.Repositories.Interfaces;
using CookingBlog.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace CookingBlog.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly CookingContext context;

    public UserRepository(CookingContext dbContext)
    {
        context = dbContext;
    }

    public async Task<DbUser> Add(DbUser user)
    {
        await context.Users.AddAsync(user);
        context.SaveChanges();

        return user;
    }

    public DbUser? GetById(int id)
    {
        return context.Users.Include(l => l.Recipes).Include(u => u.Roles).Include(u => u.Reviews).FirstOrDefault(o => o.Id == id); //todo: redo for tasks
    }

    public DbUser? GetByEmail(string email)
    {
        return context.Users.Include(l => l.Recipes).Include(u => u.Roles).Include(u => u.Reviews).FirstOrDefault(o => o.Email.Equals(email));
    }

    public async Task Update(DbUser user)
    {
        context.Users.Update(user);
        context.SaveChanges();
    }

    public Task Add(DbUser user, IDbContextTransaction cookingTransaction)
    {
        throw new NotImplementedException();
    }

    public Task Update(DbUser user, IDbContextTransaction cookingTransaction)
    {
        throw new NotImplementedException();
    }

    public async Task<IDbContextTransaction> BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
    {
        return context.Database.BeginTransaction(isolationLevel);
    }
}
