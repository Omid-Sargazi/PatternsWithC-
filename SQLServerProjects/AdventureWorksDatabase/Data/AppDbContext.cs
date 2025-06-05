using AdventureWorksDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksDatabase.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductReview> ProductReviews => Set<ProductReview>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<SalesOrderDetail> SalesOrderDetails => Set<SalesOrderDetail>();
        public DbSet<SalesOrderHeader> SalesOrderHeaders => Set<SalesOrderHeader>();
        public DbSet<Person> Persons => Set<Person>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=AdventureWorks2019;User Id=sa;Password=15935755Omid$@;Encrypt=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SalesOrderDetail>()
            .HasKey(sod => new { sod.SalesOrderID, sod.SalesOrderDetailID });
        }
    }
}