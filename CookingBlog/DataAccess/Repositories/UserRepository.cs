using CookingBlog.DataAccess.Models;
using CookingBlog.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CookingBlog.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly CookingContext context;

    public UserRepository(CookingContext dbContext)
    {
        context = dbContext;
    }

    public void Add(DbUser user)
    {
        context.Users.AddAsync(user);
        context.SaveChanges();
    }

    public DbUser? GetById(int id)
    {
        return context.Users.Include(l => l.Recipes).Include(u => u.Roles).Include(u => u.Reviews).FirstOrDefault(o => o.Id == id); //todo: redo for tasks
    }

    public DbUser? GetByEmail(string email)
    {
        return context.Users.Include(l => l.Recipes).Include(u => u.Roles).Include(u => u.Reviews).FirstOrDefault(o => o.Email.Equals(email));
    }

    public DbUser Update(DbUser user)
    {
        context.Users.Update(user);
        context.SaveChanges();

        return user;
    }
}
