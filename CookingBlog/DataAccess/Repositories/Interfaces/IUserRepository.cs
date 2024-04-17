using CookingBlog.DataAccess.Models;

namespace CookingBlog.DataAccess.Repositories.Interfaces;

public interface IUserRepository
{
    void Add(DbUser user);
    DbUser Update(DbUser user);
    DbUser? GetById(int id);
    DbUser? GetByEmail(string email);
}
