using Microsoft.EntityFrameworkCore;

namespace AdventureWorksLT2019.Data
{
    public class AdventureWorksContext : DbContext
    {
        public DbSet<Models.Customer> Customers { get; set; }
        public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
            : base(options)
        {
        }
    }
}