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

var query02 = context.Customers
    .Where(c => c.Person != null)
    .SelectMany(c => c.SalesOrdersHeaders, (c, order) => new { c, order })
    .SelectMany(co => co.order.SalesOrderDetails, (co, detail) => new
    {
        CustomerName = co.c.Person.FirstName + " " + co.c.Person.LastName,
        ProductName = detail.Product.Name
    })
    .ToList();

var customerOrders = context.Customers
.Where(c => c.Person != null)
.SelectMany(c => c.SalesOrdersHeaders, (customer, order) => new
{
    CustomerName = customer.Person.FirstName + " " + customer.Person.LastName,
    OrderDate = order.OrderDate
}
).ToList();


foreach (var p in query02)
{
    Console.WriteLine($"products are {p.CustomerName},{p.CustomerName}");
}


