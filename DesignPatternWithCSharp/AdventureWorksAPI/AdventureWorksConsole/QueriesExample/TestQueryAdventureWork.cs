using System.Threading.Tasks;
using AdventureWorksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksConsole.QueriesExample
{
    public class TestQueryAdventureWork
    {
        protected static readonly AdventureWorks2019Context _context = new AdventureWorks2019Context();

        public static async Task Run()
        {
            var query = await _context.Products
           .Include(p => p.ProductSubcategory)
           .Where(p => p.ProductSubcategory != null)
           .Take(3).ToListAsync();


            var query2 = await _context.Products
            .Include(p => p.ProductSubcategory)
            .Where(p => p.ListPrice > 1000)
            .Take(3).ToListAsync();

            var query3 =await _context.Products
            .Include(p => p.ProductInventories)
            .Where(p=>p.ProductInventories !=null)
            .Take(3)
            .ToListAsync();

            var query4 = await _context.ProductSubcategories
            .Include(ps => ps.Products)
            .Take(3)
            .ToListAsync();

            var query5 = await _context.ProductCategories
            .Include(pc => pc.ProductSubcategories)
            .Take(3)
            .ToListAsync();

            var query6 = await _context.Products
            .Include(p => p.ProductSubcategory)
            .ThenInclude(ps => ps.ProductCategory)
            .Where(p => p.ProductSubcategory != null && p.ProductSubcategory.ProductCategory != null)
            .Take(3)
            .ToListAsync();

            var query7 = await _context.Products
            .Include(p => p.ProductSubcategory)
            .Include(p => p.ProductInventories)
            .Take(3)
            .ToListAsync();

            var query8 = await _context.ProductSubcategories
            .SelectMany(ps => ps.Products)
            // .Where(p => p.Name.Contains("Bikes"))
            .Take(3)
            .ToListAsync();

            var products = await _context.ProductCategories
                .SelectMany(pc => pc.ProductSubcategories)
                .SelectMany(ps => ps.Products)
                .Take(3)
                .ToListAsync();
            var query9 = products.Select((p, index) => new
            {
                p.Name,
                RowNum = index + 1
            }).ToList();
            
            foreach (var item in query9)
            {
                Console.WriteLine($"Product:{item.Name},RowNum:{item.RowNum}");
                // Console.WriteLine("SelectMany");
                // Console.WriteLine($"Name:{item.Name},PID:{item.ProductId},PSC:{item.ProductSubcategory.Name}");
            }





            foreach (var item in query6)
                {
                    // Console.WriteLine($"Product: {item.Name},ProductSubCategory: {item.ProductSubcategoryId},Count:{item.Products.Count}");
                    // Console.WriteLine($"Product: {item.Name},ProductSubCategoryName: {item.ProductSubcategory.Name}, Product Category: {item.ProductSubcategory.ProductCategory.Name} ");
                }
        }
         
    }
}