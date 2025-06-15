using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using AdvantureWorksDatabse02.Data;
using Microsoft.EntityFrameworkCore;

namespace AdvantureWorksDatabse02.Models
{
    public class AdventureWorksQueries
    {
        private readonly AdventureWorksContext _context;
        public AdventureWorksQueries(AdventureWorksContext context)
        {
            _context = context;
        }
        public class CategorySalesResult
        {
            public string CategoryName { get; set; }
            public int ProductsSold { get; set; }
            public decimal TotalSales { get; set; }
            public decimal PercentageOfTotalSales { get; set; }

        }
        public async Task<List<CategorySalesResult>> GetCategorySalesAsync()
        {
            var totalSales = await _context.SalesOrderDetails.SumAsync(sod => sod.LineTotal);
            return await _context.SalesOrderDetails
            .Include(sod => sod.Product)
            .ThenInclude(p => p.ProductSubcategory)
            .ThenInclude(psc => psc.ProductCategory)
            .Where(sod => sod.Product.ProductSubcategory != null)
            .GroupBy(sod => sod.Product.ProductSubcategory.ProductCategory.Name)
            .Select(g => new CategorySalesResult
            {
                CategoryName = g.Key,
                ProductsSold = g.Select(sod => sod.ProductID).Distinct().Count(),
                TotalSales = g.Sum(sod => sod.LineTotal),
                PercentageOfTotalSales = Math.Round(g.Sum(sod => sod.LineTotal) * 100 / totalSales)
            }).OrderByDescending(x => x.TotalSales)
            .ToListAsync();
        }


        public class TopProducts
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int TotalSales { get; set; }
            public decimal TotalRevenue { get; set; }
        }

        public async Task<List<TopProducts>> GetTopProductAsync()
        {
            var topProducts = await _context.Products
            .Join(_context.SalesOrderDetails,
                p => p.ProductID,
                sod => sod.ProductID,
                (p, sod) => new { p, sod }
            ).GroupBy(x => new { x.p.ProductID, x.p.Name })
            .Select(g => new TopProducts
            {
                ProductId = g.Key.ProductID,
                ProductName = g.Key.Name,
                TotalSales = g.Count(),
                TotalRevenue = g.Sum(x => x.sod.LineTotal)
            }).OrderByDescending(x => x.TotalSales).Take(10).ToListAsync();
            return topProducts;

        }

        public class OrdersOfCustomersMoreThanTwo
        {
            public int CustomerId { get; set; }
            public int countSalesOrderId { get; set; }
        }

        public async Task<List<OrdersOfCustomersMoreThanTwo>> GetOrdersOfCustomersMoreThanTwosAsync()
        {
            var result = await _context.Customers
            .Where(c => c.SalesOrders.Count > 2)
            .Select(c => new OrdersOfCustomersMoreThanTwo
            {
                CustomerId = c.CustomerID,
                countSalesOrderId = c.SalesOrders.Count
            }).ToListAsync();

            return result;
        }
    }

}