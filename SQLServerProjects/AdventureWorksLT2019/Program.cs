using System.Runtime.Serialization;
using System.Security.AccessControl;
using AdventureWorksLT2019.Data;
using AdventureWorksLT2019.Models;
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

            Console.WriteLine("\n=== تعداد سفارشات هر مشتری ===");
            var orderCounts = context.SalesOrderHeaders
            .Include(o => o.Customer)
            .GroupBy(o => new { o.CustomerID, o.Customer.FirstName, o.Customer.LastName })
            .Select(g => new
            {
                CustomerName = g.Key.FirstName + " " + g.Key.LastName,
                OrderCount = g.Count()
            })
            .OrderByDescending(x => x.OrderCount)
            .Take(10)
            .ToList();

            foreach (var result in orderCounts)
            {
                Console.WriteLine($"Customer: {result.CustomerName}, Orders: {result.OrderCount}");
            }

            Console.WriteLine("\n=== 5 محصول پرفروش ===");
            var topProducts = context.SalesOrderDetails
            .GroupBy(d => d.ProductID)
            .Select(g => new
            {
                ProductId = g.Key,
                TotalQuantitySold = g.Sum(d => d.OrderQty)
            }).Join(context.Products, sale => sale.ProductId, product => product.ProductID, (sale, product) => new
            {
                ProductName = product.Name,
                sale.TotalQuantitySold
            }).OrderByDescending(x => x.TotalQuantitySold)
            .Take(5).ToList();


            foreach (var product in topProducts)
            {
                Console.WriteLine($"Product: {product.ProductName}, Sold: {product.TotalQuantitySold}");
            }
            Console.WriteLine("\n======================== 5 محصول پرفروش ===============");
            var TopProducts = context.SalesOrderDetails
            .Include(d => d.Product)
            .GroupBy(d => d.Product.ProductID)
            .Select(g => new
            {
                ProductName = g.First().Product.Name,
                TotalQuantitySold = g.Sum(d => d.OrderQty)
            }).OrderByDescending(x => x.TotalQuantitySold)
            .Take(5).ToList();

            foreach (var product in TopProducts)
            {
                Console.WriteLine($"Product: {product.ProductName}, Sold: {product.TotalQuantitySold}");
            }

            Console.WriteLine("\n=== سفارشات مشتری با ID 1 ===");
            var CustomerOrders = context.SalesOrderHeaders
            .Where(o => o.CustomerID == 1)
            .Join(context.Customers,
                order => order.CustomerID,
                customer => customer.CustomerID,
                (order, customer) => new
                {
                    CustomerName = customer.FirstName + " " + customer.LastName,
                    order.SalesOrderNumber,
                    order.OrderDate,
                }
            ).ToList();

            foreach (var order in CustomerOrders)
            {
                Console.WriteLine($"Customer: {order.CustomerName}, Order: {order.SalesOrderNumber}, Date: {order.OrderDate}, Total:");
            }
            Console.WriteLine("\n=== محصولات در دسته‌بندی Bikes ===");
            var bikes = context.Products
            .Where(p => p.ProductCategoryID == 1)
            .Join(context.productCategories,
                product => product.ProductCategoryID,
                category => category.ProductCategoryID,
                (product, category) => new
                {
                    ProductName = product.Name,
                    CategoryName = category.Name,
                    product.ListPrice
                }
            ).OrderBy(p => p.ListPrice).ToList();
            foreach (var bike in bikes)
            {
                Console.WriteLine($"Product: {bike.ProductName}, Category: {bike.CategoryName}, Price: {bike.ListPrice}");
            }

            Console.WriteLine("\n=== آدرس‌های مشتریان در Seattle ===");
            var seattleCustomers = context.customerAddresses
            .Join(context.Addresses,
            ca => ca.AddressID,
            a => a.AddressID,
            (ca, a) => new { ca, a }
            ).Join(context.Customers,
                x => x.ca.CustomerID,
                c => c.CustomerID,
                (x, c) => new
                {
                    CustomerName = c.FirstName + " " + c.LastName,
                    x.a.AddressLine1,
                    x.a.City,
                    x.a.StateProvince
                }
            ).Where(x => x.City == "Seattle").ToList();
            foreach (var customer in seattleCustomers)
            {
                Console.WriteLine($"Customer: {customer.CustomerName}, Address: {customer.AddressLine1}, {customer.City}, {customer.StateProvince}");
            }

            Console.WriteLine("\n=== محصولات بدون فروش ===");
            var unsoldProducts = context.Products
            .GroupJoin(context.SalesOrderDetails,
                p => p.ProductID,
                sod => sod.ProductID,
                (p, sod) => new { Product = p, Sales = sod })
            .Where(x => !x.Sales.Any())
            .Select(x => new
            {
                ProductName = x.Product.Name,
                x.Product.ListPrice
            })
            .ToList();


            Console.WriteLine("\n=== تعداد سفارشات در هر سال ===");

            var ordersByYear = context.SalesOrderHeaders
            .GroupBy(o => o.OrderDate.Year)
            .Select(g => new
            {
                Year = g.Key,
                OrderCount = g.Count()
            }).OrderBy(x => x.Year)
            .ToList();


            Console.WriteLine("\n=== مشتریان با چندین آدرس ===");

            var multiAddressCustomers = context.customerAddresses
            .GroupBy(ca => ca.CustomerID)
            .Where(g => g.Count() > 1)
            .Join(context.Customers,
                g => g.Key,
                c => c.CustomerID,
                (g, c) => new
                {
                    CustomerName = c.FirstName + " " + c.LastName,
                    AddressCount = g.Count()
                }
            ).ToList();

            Console.WriteLine("\n=== میانگین قیمت محصولات فروخته‌شده ===");
            var averagePrice = context.SalesOrderDetails
            .Join(context.Products,
                sod => sod.ProductID,
                p => p.ProductID,
                (sod, p) => new
                {
                    ProductName = p.Name,
                    sod.UnitPrice,
                }
            ).GroupBy(x => x.ProductName)
            .Select(g => new
            {
                ProductName = g.Key,
                AveragePrice = g.Average(x => x.UnitPrice)
            }
            ).OrderByDescending(x => x.AveragePrice)
            .Take(5)
            .ToList();

            Console.WriteLine("\n=== محصولات با مدل Classic ===");
            var classicProducts = context.Products
            .Join(context.ProductModels,
                p => p.ProductModelID,
                pm => pm.ProductModelID,
                (p, pm) => new { Product = p, ProductModel = pm }
            ).Where(x => x.ProductModel.Name.Contains("Classic"))
            .Select(x => new
            {
                ProductName = x.Product.Name,
                ModelName = x.ProductModel.Name,
                x.Product.ListPrice
            }).ToList();

            Console.WriteLine("\n=== مشتریان بدون آدرس ===");
            var customersNoAddress = context.Customers
            .GroupJoin(context.customerAddresses,
            c => c.CustomerID,
            ca => ca.CustomerID,
            (c, ca) => new { Customer = c, Address = ca })
            .Where(x => !x.Address.Any())
            .Select(x => new
            {
                CustomerName = x.Customer.FirstName + " " + x.Customer.LastName,
                x.Customer.EmailAddress
            }).ToList();

            Console.WriteLine("\n=== سفارشات با تخفیف ===");
            var discountedOrders = context.SalesOrderDetails
            .Join(context.Products,
                sod => sod.ProductID,
                p => p.ProductID,
                (sod, p) => new
                {
                    sod.SalesOrderID,
                    ProductName = p.Name,
                    sod.UnitPrice,
                    p.ListPrice,
                    Discount = p.ListPrice - sod.UnitPrice

                }
            ).Where(x => x.UnitPrice < x.ListPrice).
            OrderByDescending(x => x.Discount)
            .Take(5)
            .ToList();

            Console.WriteLine("\n=== دسته‌بندی‌های با بیشترین محصولات ===");
            var topCategories = context.Products
            .GroupBy(p => p.ProductCategoryID)
            .Join(context.productCategories,
                g => g.Key,
                pc => pc.ProductCategoryID,
                (g, pc) => new
                {
                    CategoryName = pc.Name,
                    ProductCount = g.Count()
                }
            ).OrderByDescending(x => x.ProductCount)
            .Take(5)
            .ToList();
        }
            

    }
}