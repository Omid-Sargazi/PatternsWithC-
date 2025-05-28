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
        }
    }
}