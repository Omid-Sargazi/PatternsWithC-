using AdventureWorksDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksDatabase.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> products => Set<Product>();
        public DbSet<ProductReview> ProductReviews => Set<ProductReview>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=AdventureWorks2019;User Id=sa;Password=15935755Omid$@;Encrypt=False;");
        }
    }
}