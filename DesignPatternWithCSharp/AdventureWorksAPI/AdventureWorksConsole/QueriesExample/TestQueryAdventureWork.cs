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

            var query10 = await _context.Products
            .Include(p => p.ProductSubcategory)
            .ThenInclude(ps => ps.ProductCategory)
            .Where(p => p.ListPrice > 500 && p.ProductSubcategory != null && p.ProductSubcategory.ProductCategory != null).Take(3)
            .ToListAsync();

            var result10 = query10.Select(q => new
            {
                q.Name,
                q.ListPrice,
                Subcategory = q.ProductSubcategory.Name,
                Category = q.ProductSubcategory.ProductCategory.Name
            }).ToList();


            var query11 = await _context.Products
            .Join(_context.ProductSubcategories,
                p => p.ProductSubcategoryId,
                ps => ps.ProductCategoryId,
                (p, ps) => new { p, ps }
            ).Join(_context.ProductCategories,
                temp => temp.ps.ProductCategoryId,
                pc => pc.ProductCategoryId,
                (temp, pc) => new
                {
                    temp.p.ListPrice,
                    temp.p.Name,
                    temp.ps.ProductCategoryId,
                    Subcategory = temp.ps.Name,
                    Category = pc.Name
                }
            ).Where(x => x.ListPrice > 500).OrderByDescending(x => x.ListPrice).Take(3).ToListAsync();


            var query12 = await _context.Products
            .Include(p => p.ProductSubcategory)
            .ThenInclude(ps => ps.ProductCategory)
            .Include(p => p.ProductInventories)
            .Where(p => p.ProductInventories.Any() && p.ProductSubcategory != null && p.ProductSubcategory.ProductCategory != null)
            .Take(3).ToListAsync();

            var result12 = query12.Select(p => new
            {
                p.Name,
                InventoryCount = p.ProductInventories.Count,
                Category = p.ProductSubcategory.ProductCategory.Name,
            }).ToList();



            var query12_1 = await _context.Products
            .Join(_context.ProductSubcategories,
                p => p.ProductSubcategoryId,
                ps => ps.ProductCategoryId,
                (p, ps) => new { p, ps }
            )
            .Join(_context.ProductCategories,
                temp => temp.ps.ProductCategoryId,
                pc => pc.ProductCategoryId,
                (temp, pc) => new { temp.p, temp.ps, pc }
            )
            .Join(_context.ProductInventories,
                temp => temp.p.ProductId,
                pi => pi.ProductId,
                (temp, pi) => new
                {
                    temp.p.Name,
                    InventoryCount=1,
                    Category = temp.pc.Name,

                }
            ).
            Take(3)
            .ToListAsync();


            foreach (var item in query12_1)
            {
            Console.WriteLine($"Product: {item.Name}, Inventory: {item.InventoryCount}, Category: {item.Category}");                    // Console.WriteLine($"Product:{item.Name},Category:{item.Category},SubCategory:{item.Subcategory},Price:{item.ListPrice}");
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