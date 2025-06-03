using AdventureWorksConsole.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksConsole.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductModel> ProductModels => Set<ProductModel>();
        public DbSet<SalesOrderDetail> SalesOrderDetails => Set<SalesOrderDetail>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Person> People => Set<Person>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost;Database=AdventureWorks2019;User Id=sa;Password=15935755Omid$@;Encrypt=False;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product", "Production");
        }
    }
    }
