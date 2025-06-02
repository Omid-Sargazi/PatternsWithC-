// See https://aka.ms/new-console-template for more information
using AdventureWorksConsole.Data;

Console.WriteLine("Hello, World!");

var context = new AppDbContext();
var products = context.Products.Take(5).ToList();

foreach (var p in products)
{
    Console.WriteLine($"{p.Name} - {p.ListPrice}");
}