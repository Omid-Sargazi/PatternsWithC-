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


var orders = context.SalesOrderHeaders
.Where(soh => soh.OrderDate >= new DateTimeOffset(2014, 1, 1, 0, 0, 0, TimeSpan.Zero)
    && soh.OrderDate < new DateTimeOffset(2015, 1, 1, 0, 0, 0, TimeSpan.Zero)
).Select(soh => new
{
    soh.Customer.Person.FirstName,
    soh.Customer.Person.LastName,
    soh.SalesOrderID,
    soh.OrderDate
}).ToList();

var customerOrderss = context.Customers
.Select(c => new
{
    c.CustomerId,
    c.Person.LastName,
    c.Person.FirstName,
    OrderCount = c.SalesOrdersHeaders.Count()
}
);
Console.WriteLine($"All orders are :{customerOrderss.Count()}");


// foreach (var p in orders)
// {
//     Console.WriteLine($"products are {p.FirstName},{p.LastName}");
// }


