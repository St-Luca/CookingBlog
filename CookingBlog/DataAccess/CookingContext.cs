using CookingBlog.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CookingBlog.DataAccess
{
    public class CookingContext : DbContext
    {
        public CookingContext(DbContextOptions<CookingContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<DbRecipe> Recipes { get; set; } = default!;
        /* public DbSet<Locality> Localities { get; set; } = default!;
         public DbSet<LocalityCost> LocalityCosts { get; set; } = default!;
         public DbSet<Organization> Organizations { get; set; } = default!;
         public DbSet<Animal> Animals { get; set; } = default!;
         public DbSet<CaptureAct> Acts { get; set; } = default!;
         public DbSet<Contract> Contracts { get; set; } = default!;
         public DbSet<Application> Applications { get; set; } = default!;*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbRecipe o1 = new DbRecipe { Id = 1 };
            modelBuilder.Entity<DbRecipe>().HasData(o1);
        }
    }
}
