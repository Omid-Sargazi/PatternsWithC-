using AdventureWorksLT2019.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksLT2019.Data
{
    public class AdventureWorksContext : DbContext
    {
        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public DbSet<SalesOrderDetail>  SalesOrderDetails { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }

        public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
            : base(options)
        {
        }
    }
}