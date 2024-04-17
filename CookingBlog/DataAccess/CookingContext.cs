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
         public DbSet<DbCategory> Categories { get; set; } = default!;
         public DbSet<DbReview> Reviews { get; set; } = default!;
         public DbSet<DbProduct> Products { get; set; } = default!;
         public DbSet<DbRole> Roles { get; set; } = default!;
         public DbSet<DbUser> Users { get; set; } = default!;
         public DbSet<DbRecipeCategory> RecipeCategories { get; set; } = default!;
         public DbSet<DbRecipeProduct> RecipeProducts { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbRecipeCategory>()
        .HasKey(sc => new { sc.RecipeId, sc.CategoryId });

            modelBuilder.Entity<DbRecipe>()
            .HasMany(lc => lc.Categories)
            .WithOne(c => c.Recipe)
            .HasForeignKey(lc => lc.RecipeId);

            modelBuilder.Entity<DbCategory>()
           .HasMany(lc => lc.Recipes)
           .WithOne(c => c.Category)
           .HasForeignKey(lc => lc.CategoryId);

            modelBuilder.Entity<DbRecipeProduct>()
        .HasKey(sc => new { sc.RecipeId, sc.ProductId });

            modelBuilder.Entity<DbRecipe>()
            .HasMany(lc => lc.Products)
            .WithOne(c => c.Recipe)
            .HasForeignKey(lc => lc.RecipeId);

            modelBuilder.Entity<DbProduct>()
           .HasMany(lc => lc.Recipes)
           .WithOne(c => c.Product)
           .HasForeignKey(lc => lc.ProductId);

            modelBuilder.Entity<DbUser>()
                   .HasMany(p => p.Reviews)
                   .WithOne(d => d.User)
                   .HasForeignKey(d => d.UserId);

            modelBuilder.Entity<DbUser>()
                   .HasMany(p => p.Recipes)
                   .WithOne(d => d.User)
                   .HasForeignKey(d => d.UserId);

            modelBuilder.Entity<DbUser>()
                   .HasMany(p => p.Roles)
                   .WithOne(d => d.User)
                   .HasForeignKey(d => d.UserId);

            modelBuilder.Entity<DbRecipe>()
                   .HasMany(p => p.Reviews)
                   .WithOne(d => d.Recipe)
                   .HasForeignKey(d => d.RecipeId);
        }
    }
}
