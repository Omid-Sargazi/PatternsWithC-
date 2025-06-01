using AdventureWorksLT2019_2.Data;
using AdventureWorksLT2019_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorksLT2019_2
{
    public class Program
{
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            // تنظیم Service Provider
            var services = new ServiceCollection();
            services.AddDbContext<AdventureWorksContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            var serviceProvider = services.BuildServiceProvider();

            // نمونه‌سازی DbContext
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AdventureWorksContext>();

            // نمونه کوئری: نمایش 10 مشتری
            var customers = context.Customers
                .Where(c => c.CompanyName != null)
                .Take(10)
                .ToList();

            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer: {customer.FirstName} {customer.LastName}, Company: {customer.CompanyName}");
            }

            Console.WriteLine("\n=== 5 محصول پرفروش ===");
            var groups = context.SalesOrderDetails
           .GroupBy(sod => sod.ProductID)
           .ToList();

            var productSales = groups
            .Select(g => new
            {
                ProductId = g.Key,
                TotalSold = g.Sum(x => x.OrderQty)
            }).ToList();
            foreach (var g in groups)
            {
                foreach (var item in g)
                {
                    Console.WriteLine($"OrderQty:{item.OrderQty}");
                }
            }

            foreach (var p in productSales)
            {
                Console.WriteLine($"ProductID: {p.ProductId}, TotalSold:{p.TotalSold}");
            }

            var joinedWithProducts = productSales
            .Join(context.Products,
                ps => ps.ProductId,
                p => p.ProductID,
                (ps, p) => new
                {
                    ProductName = p.Name ?? "unknown",
                    ps.TotalSold
                }
            ).ToList();

            foreach (var item in joinedWithProducts)
            {
                Console.WriteLine($"Product: {item.ProductName}, Sold: {item.TotalSold}");
            }

            var topProducts = joinedWithProducts
            .OrderByDescending(x => x.TotalSold)
            .Take(5)
            .ToList();
            foreach (var top in topProducts)
            {
                Console.WriteLine($"🔥 Top Product: {top.ProductName}, Sold: {top.TotalSold}");
            }


    }
}
}