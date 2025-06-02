// See https://aka.ms/new-console-template for more information
using AdventureWorksConsole.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;

Console.WriteLine("Hello, World!");

var context = new AppDbContext();
var products = context.Products.Take(5).ToList();
//price more than 1000
var productsMoreThan1000 = context.Products.Where(p => p.ListPrice > 1000).ToList();
var MakeFlag = context.Products.Where(p => p.MakeFlag).ToList();

var productsAZ = context.Products.OrderBy(p => p.Name).ToList();

var productsIn2013 = context.Products.FirstOrDefault(p => p.SellStartDate.Year >= 2013);
Console.WriteLine($"Product is:{productsIn2013.ProductId}");


var productbetween500and1500 = context.Products.Where(p => p.ListPrice >= 500 && p.ListPrice <= 1500).ToList();

var productIncludeBike = context.Products.Where(p => p.Name.Contains("Bike")).ToList();

var numberOfProducts = context.Products.Count();
Console.WriteLine($"number Of Products is: {numberOfProducts}");

////////////////////////////////Join///////////////////////////////////
var productWithModel = context.Products
.Join(context.ProductModels,
    p => p.ProductModelId,
    pm => pm.ProductModelId,
    (p, pm) => new { p.Name, ModelName = pm.Name }
).Take(5).ToList();



var OrderLessThan500 = context.SalesOrderDetails.Where(s => s.UnitPrice < 500).ToList();

var totalPriceOfOrders = context.SalesOrderDetails.Sum(o => o.UnitPrice * o.OrderQty);
var SellProductAtleatOnce = context.SalesOrderDetails.Select(s => s.ProductId).Distinct().Count();
Console.WriteLine($"orderMoreThan3 {SellProductAtleatOnce}");

var orderMoreThan3 = context.SalesOrderDetails.Where(s => s.OrderQty > 3).Take(5)
.ToList();

// 16. تعداد سفارش برای هر ProductId
var OrderForEachProductId = context.SalesOrderDetails
.GroupBy(s => s.ProductId)
.Select(g => new { PriductId = g.Key, Count = g.Count() })
.Take(5).ToList();

var moreOderForAProduct = context.SalesOrderDetails
.GroupBy(s => s.ProductId)
.Select(g => g.Sum(s => s.OrderQty)).Max();

Console.WriteLine($"moreOderForAProduct:{moreOderForAProduct}");

var soldProductIds = context.SalesOrderDetails.Select(s => s.ProductId).Distinct();
var unsoldProducts = context.Products.Where(p => !soldProductIds.Contains(p.ProductId)).ToList();


context.Customers.Where(c => c.AccountNumber != null).Take(5).ToList();

context.Customers.Count();

foreach (var p in unsoldProducts)
{
    Console.WriteLine($"ProcutWithModel:  {p.Name} ----- {p.ProductId}");
}