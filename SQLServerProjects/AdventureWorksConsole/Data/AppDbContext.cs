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
        public DbSet<AddressType> AddressTypes => Set<AddressType>();
        public DbSet<StateProvince> StateProvinces => Set<StateProvince>();
        public DbSet<BusinessEntityAddress> BusinessEntityAddress => Set<BusinessEntityAddress>();
        public DbSet<Address> Addresses => Set<Address>();

        public DbSet<EmailAddress> EmailAddresses => Set<EmailAddress>();
        public DbSet<SalesOrderHeader> salesOrderHeaders => Set<SalesOrderHeader>();
        public DbSet<ProductSubcategory> productSubcategories => Set<ProductSubcategory>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost;Database=AdventureWorks2019;User Id=sa;Password=15935755Omid$@;Encrypt=False;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product", "Production");
        }
    }
    }
