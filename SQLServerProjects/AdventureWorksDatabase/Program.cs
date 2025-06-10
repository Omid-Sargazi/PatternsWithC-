// See https://aka.ms/new-console-template for more information
using AdventureWorksDatabase.Data;
using AdventureWorksDatabase.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
var context = new AppDbContext();

// نادرست:
var task1 = context.Products.ToListAsync();
var task2 = context.Customers.ToListAsync();
await Task.WhenAll(task1, task2);

// صحیح:
var products = await context.Products.ToListAsync();
var customers = await context.Customers.ToListAsync();

foreach (var p in products)
{
    Console.WriteLine($"Name:{p.Name +p.ListPrice}");
}
