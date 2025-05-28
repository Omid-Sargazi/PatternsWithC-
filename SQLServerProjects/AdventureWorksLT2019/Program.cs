using AdventureWorksLT2019.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorksApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // تنظیم Configuration
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

            Console.WriteLine("\n=== 10 محصول گران‌تر از 100 ===");
            var expensiveProducts = context.Products
            .Where(p => p.ListPrice > 100)
            .OrderByDescending(p => p.ListPrice)
            .Take(10)
            .ToList();

            foreach (var product in expensiveProducts)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.ListPrice}");
            }

            Console.WriteLine("\n=== سفارشات مشتری‌ها ===");
            var customerOrders = context.Customers
            .Join(context.SalesOrderHeaders, customer => customer.CustomerID, order => order.CustomerID,
            (customer, order) => new
            {
                CustomerName = customer.FirstName,
                OrderNumber = order.SalesOrderNumber,
                OrderDate = order.OrderDate
            }
            ).Take(10)
            .ToList();

            foreach (var result in customerOrders)
            {
                Console.WriteLine($"Customer: {result.CustomerName}, Order: {result.OrderNumber}, Date: {result.OrderDate}");
            }
        }
    }
}