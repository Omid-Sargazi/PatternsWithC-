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


var productSales = context.SalesOrderDetails
.Where(sod => sod.SalesOrderHeader.OrderDate.Year == 2014 &&
sod.SalesOrderHeader.Customer.Person.LastName.StartsWith("S"))
.GroupBy(sod => sod.Product.Name)
.Where(g => g.Sum(x => x.OrderQty * x.UnitPrice) > 10000)
.OrderByDescending(g => g.Sum(x => x.OrderQty * x.UnitPrice))
.Select(g => new
{
    ProductName = g.Key,
    OrderCount = g.Select(x => x.SalesOrderHeader.SalesOrderID).Distinct().Count(),
    TotalSales = g.Sum(x => x.OrderQty * x.UnitPrice)

}
);
var customers = context.Customers
.Select(c => new
{
    c.CustomerId,
    c.Person.LastName,
    c.Person.FirstName
});

var productSaless = context.SalesOrderDetails
.Where(sod => sod.SalesOrderHeader.OrderDate.Year == 2014
&& sod.SalesOrderHeader.Customer.Person.LastName.StartsWith("S"))
.GroupBy(sod => sod.Product.Name)
.Where(g => g.Sum(x => x.OrderQty * x.UnitPrice) > 10000)
.OrderByDescending(g => g.Sum(x => x.OrderQty * x.UnitPrice))
.Select(g => new
{
    ProductName = g.Key,
    OrderCount = g.Select(x => x.SalesOrderHeader.SalesOrderID).Distinct().Count(),
    TotalCount = g.Sum(x => x.OrderQty * x.UnitPrice)
});

var customerss = context.Customers
.Where(c => c.SalesOrdersHeaders.Any())
.Select(c => new { c.CustomerId, c.Person.FirstName, c.Person.LastName });


var productsBetween100and500 = context.Products
.Where(p => p.ListPrice >= 100 && p.ListPrice <= 500)
.OrderBy(p => p.ListPrice)
.Select(p => new { p.ProductID, p.Name, p.ListPrice });


var orderCount = context.SalesOrderHeaders
.Count(soh => soh.OrderDate.Year == 2014);

var customersStartWithS = context.Customers
.Where(c => c.Person.LastName.StartsWith("S"))
.Select(c => new { c.CustomerId, c.Person.FirstName, c.Person.LastName });

var unsoldProducts = context.Products
.Where(p => !p.SalesOrderDetails.Any())
.Select(p => new { p.ProductID, p.Name });

var customerSales = context.SalesOrderHeaders
.GroupBy(soh => soh.CustomerId)
.Select(g => new { CustomerID = g.Key, TotalSale = g.Sum(soh => soh.SubTotal) });

var customersMoreThan3Orders = context.SalesOrderHeaders
.GroupBy(soh => soh.CustomerId)
.Where(g => g.Count() > 3)
.Select(g => new { CustomerID = g.Key, OrderCount = g.Count() });

foreach (var p in customers)
{
    Console.WriteLine($"products are {p.CustomerId},{p.LastName}");
}


