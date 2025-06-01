using Microsoft.EntityFrameworkCore;

namespace AdventureWorksLT2019_2.Data
{
    public class AdventureWorksContext : DbContext
    {
        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.SalesOrderHeader> SalesOrderHeaders { get; set; }
        public DbSet<Models.SalesOrderDetail> SalesOrderDetails { get; set; }
        public DbSet<Models.ProductCategory> ProductCategories { get; set; }
        public DbSet<Models.Address> Addresses { get; set; }
        public DbSet<Models.CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Models.ProductModel> ProductModels { get; set; }

        public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
            : base(options)
        {
        }
    }
}