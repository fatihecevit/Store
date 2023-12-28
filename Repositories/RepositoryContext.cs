using Microsoft.EntityFrameworkCore;
using Entities.Models;
namespace Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; private set; }
        public DbSet<Category> Categories { get; private set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
            .HasData(
                new Product() { ProductId = 1, ProductName = "Computer", Price = 17_00 },
                new Product() { ProductId = 2, ProductName = "Keyboard", Price = 1_00 },
                new Product() { ProductId = 3, ProductName = "Mouse", Price = 500 }
            );

            modelBuilder.Entity<Category>()
            .HasData(
                new Category() { CategoryId = 1, CategoryName = "Book", },
                new Category() { CategoryId = 2, CategoryName = "Electronic" }
            );

        }
    }
}