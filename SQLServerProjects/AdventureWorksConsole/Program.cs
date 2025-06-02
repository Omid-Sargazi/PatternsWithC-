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

var orderMoreThan3 = context.SalesOrderDetails.Where(s => s.OrderQty > 3).Take(5)
.ToList();
foreach (var p in orderMoreThan3)
{
    Console.WriteLine($"ProcutWithModel:  {p.ProductId} ----- {p.SalesOrderId}");
}