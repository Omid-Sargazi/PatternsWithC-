using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using AdventureWorksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksConsole.QueriesExample
{
    public class ProductRanked
    {
        protected static readonly AdventureWorks2019Context _context = new AdventureWorks2019Context();

        public static async Task RunProductRanked()
        {
            // var result = await _context.Products
            // .Join(_context.ProductSubcategories,
            // p => p.ProductSubcategoryId,
            // ps => ps.ProductSubcategoryId,
            // (p, ps) => new { p, ps }
            // ).Join(_context.ProductCategories,
            //     temp => temp.ps.ProductCategoryId,
            //     pc => pc.ProductCategoryId,
            //     (temp, pc) => new
            //     {
            //         temp.p.Name,
            //         temp.p.ListPrice,
            //         Category = pc.Name
            //     }
            // ).GroupBy(x => x.Category)
            // .SelectMany(g => g.OrderByDescending(x => x.ListPrice))
            // .Take(3).Select((item, index) => new
            // {
            //     item.Name,
            //     item.ListPrice,
            //     item.Category,
            //     RowNum = index + 1,
            // }).ToListAsync();


           var query = await _context.Products
        .Include(p => p.ProductSubcategory)
        .ThenInclude(ps => ps.ProductCategory)
        .Where(p => p.ProductSubcategory != null && p.ProductSubcategory.ProductCategory != null)
        .GroupBy(p => p.ProductSubcategory.ProductCategory.Name)
        .Select(g => new
        {
            Category = g.Key,
            Products = g.OrderByDescending(p => p.ListPrice).Take(3).Select(p => new
            {
                p.Name,
                p.ListPrice
            }).ToList()
        })
        .ToListAsync();
        
        var result = query.SelectMany((g, index) => g.Products.Select(p => new
    {
        p.Name,
        p.ListPrice,
        g.Category,
        RowNum = index + 1
    })).ToList();

    foreach (var item in result)
    {
        Console.WriteLine($"Name:{item.Name},ListPrice:{item.ListPrice},Category:{item.Category},RowNum:{item.RowNum}");
    }


        //    var navigationResult2 =  _context.ProductCategories
            //     .SelectMany(pc => pc.ProductSubcategories
            //         .SelectMany(ps => ps.Products
            //             .Select(p => new
            //             {
            //                 p.Name,
            //                 p.ListPrice,
            //                 Category = pc.Name
            //             })
            //             .OrderByDescending(x => x.ListPrice)
            //             .Take(3) // 3 محصول برتر از هر دسته
            //         ))
            //     .Select((item, index) => new
            //     {
            //         item.Name,
            //         item.ListPrice,
            //         item.Category,
            //         RowNum = index + 1
            //     })
            //     .ToList();

           

        }
    }
}