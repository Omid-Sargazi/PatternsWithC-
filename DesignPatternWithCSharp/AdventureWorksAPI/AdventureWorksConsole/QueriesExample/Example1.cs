using AdventureWorksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksConsole.QueriesExample
{
    public class Example1
    {
        protected static readonly AdventureWorks2019Context _context = new AdventureWorks2019Context();
        // public Example1(AdventureWorks2019Context context)
        // {
        //     _context = context;
        // }
        public static async Task Run()
        {
            var result = await _context.SalesOrderDetails.Where(x => x.ProductId == 870)
            .Select(x => new { x.SalesOrderId, x.OrderQty })
            .ToListAsync();


            var result2 = await _context.Products
            .Join(_context.ProductSubcategories,
             p => p.ProductSubcategoryId,
             ps => ps.ProductSubcategoryId,
             (p, ps) => new { p, ps }


            ).GroupBy(x => x.ps.Name)
            .Select(g => new
            {
                Subcategory = g.Key,
                AvgPrice = g.Average(x => x.p.ListPrice)
            }).ToListAsync();


            var mostOrders = await _context.SalesOrderDetails
            .GroupBy(x => x.ProductId)
            .Select(g => new { ProductId = g.Key, MaxQty = g.Max(x => x.OrderQty) })
            .ToListAsync();

            var priceBetween100And1000 = _context.Products
            .Where(p => p.ListPrice >= 100 && p.ListPrice <= 1000)
            .ToListAsync();

            var subcategoryWithMore10Product = _context.Products
            .Join(_context.ProductSubcategories,
                p => p.ProductSubcategoryId,
                ps => ps.ProductSubcategoryId,
                (p, ps) => new { p, ps }

            ).GroupBy(x => x.ps.Name)
            .Where(g => g.Count() > 10)
            .Select(g => new { subCategory = g.Key, ProductCount = g.Count() }).ToListAsync();

            var orderInSeptember = _context.SalesOrderHeaders
            .Where(x => x.OrderDate.Month == 12)
            .Select(x => new { x.SalesOrderId, x.OrderDate })
            .ToListAsync();

            var orderPerYear = _context.SalesOrderHeaders
            .GroupBy(x => x.OrderDate.Year)
            .Select(g => new { Year = g.Key, Count = g.Count() })
            .ToListAsync();

            var mostProductWithSubproducts = _context.Products
            .Join(_context.ProductSubcategories,
                p => p.ProductSubcategoryId,
                ps => ps.ProductSubcategoryId,
                (p, ps) => new { p, ps.Name }

            )
            .GroupBy(x => x.Name)
            .OrderByDescending(g => g.Key)
            .Take(3)
            .Select(g => new { Subcategory = g.Key, Count = g.Count() })
            .ToListAsync(); 

            
            foreach (var item in mostOrders)
            {
                Console.WriteLine($"Product ID: {item.ProductId}, Max Quantity: {item.MaxQty}");
            }

            foreach (var item in result)
                {
                    //Console.WriteLine($"{item.SalesOrderId},{item.OrderQty}");
                }
            
        }
    }
}