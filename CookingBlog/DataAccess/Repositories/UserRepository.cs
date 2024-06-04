using CookingBlog.DataAccess.Models;
using CookingBlog.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

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
        return context.Users.Include(l => l.Recipes).Include(u => u.Roles).Include(u => u.Reviews).FirstOrDefault(o => o.Email.Equals("email"));
    }

    public async Task Update(DbUser user)
    {
        context.Entry(user).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task Add(DbUser user, IDbContextTransaction cookingTransaction)
    {
        context.Database.UseTransaction(cookingTransaction.GetDbTransaction());
        await context.Users.AddAsync(user);
        context.SaveChanges();
    }

    public async Task Update(DbUser user, IDbContextTransaction cookingTransaction)
    {
        context.Database.UseTransaction(cookingTransaction.GetDbTransaction());
        context.Users.Update(user);
        context.SaveChanges();
    }

    public async Task<IDbContextTransaction> BeginTransaction(System.Data.IsolationLevel isolationLevel = System.Data.IsolationLevel.Unspecified)
    {
        return context.Database.BeginTransaction(isolationLevel);
    }
}
