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

// var query = context.Customers
// .Where(c => c.PersonId != null)
// .SelectMany(c => c.SalesOrdersHeaders, (c, order) => new
// {
//     CustomerName = c.Person.FirstName + " " + c.Person.LastName,
//     order.SalesOrderNumber
// }
// ).ToList();

var query = context.Customers
    .Where(c => c.Person != null)
    .SelectMany(c => c.SalesOrdersHeaders, (c, order) => new
    {
        CustomerName = c.Person.FirstName + " " + c.Person.LastName,
        order.SalesOrderNumber
    })
    .ToList();

foreach (var p in query)
{
    Console.WriteLine($"products are {p.CustomerName},{p.SalesOrderNumber}");
}


