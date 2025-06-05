// See https://aka.ms/new-console-template for more information
using AdventureWorksDatabase.Data;
using AdventureWorksDatabase.Models;

Console.WriteLine("Hello, World!");
var context = new AppDbContext();
var products = context.Products.Take(5).ToList();

//////////////////////
var productReviews = context.ProductReviews
.Join(context.Products,
    review => review.ProductID,
    product => product.ProductID,
    (review, product) => new
    {
        ProductName = product.Name,
        review.ReviewerName,
        review.ReviewDate,
        review.Comments
    }
).ToList();



foreach (var p in productReviews)
{
    Console.WriteLine($"products are {p.ProductName},{p.ReviewDate}");
}


