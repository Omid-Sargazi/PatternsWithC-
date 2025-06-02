// See https://aka.ms/new-console-template for more information
using AdventureWorksConsole.Data;

Console.WriteLine("Hello, World!");

var context = new AppDbContext();
var products = context.Products.Take(5).ToList();
//price more than 1000
var productsMoreThan1000 = context.Products.Where(p => p.ListPrice > 1000).ToList();
var MakeFlag = context.Products.Where(p => p.MakeFlag).ToList();

var productsAZ = context.Products.OrderBy(p => p.Name).ToList();

foreach (var p in productsAZ)
{
    Console.WriteLine($"{p.Name} - {p.ListPrice}");
}