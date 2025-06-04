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

var emails = context.Customers
    .Where(c => c.PersonId != null)
    .Join(context.People,
        c => c.PersonId,
        p => p.BusinessEntityId,
        (c, p) => new { p.BusinessEntityId, p.FirstName, p.LastName })
    .Join(context.EmailAddresses,
        p => p.BusinessEntityId,
        e => e.BusinessEntityId,
        (p, e) => new
        {
            p.FirstName,
            p.LastName,
            e.Email
        })
    .Take(10).ToList();

var californiaCustomers = context.Customers
.Where(c => c.PersonId != null)
.Join(context.People,
    c => c.PersonId,
    p => p.BusinessEntityId,
    (c, p) => new { c.CustomerId, Person = p }
).Join(context.BusinessEntityAddress,
    cp => cp.Person.BusinessEntityId,
    bea => bea.BusinessEntityId,
    (cp, bea) => new { cp.CustomerId, cp.Person, bea }

).Join(context.Addresses,
    cpbea => cpbea.bea.AddressId,
    a => a.AddressId,
    (cpbea, address) => new { cpbea.CustomerId, cpbea.Person, address }
).Join(context.StateProvinces,
     cpbea => cpbea.address.StateProvinceId,
     sp => sp.StateProvinceId,
     (cpbea, sp) => new
     {
         CustomerID = cpbea.CustomerId,
         FirstName = cpbea.Person.FirstName,
         LastName = cpbea.Person.LastName,
         AddressLine1 = cpbea.address.AddressLine1,
         StateProvinceCode = sp.StateProvinceCode
     }
).Where(x => x.StateProvinceCode == "CA").ToList();


var peopleWithEmails = context.People
.Join(context.EmailAddresses,
    person => person.BusinessEntityId,
    email => email.BusinessEntityId,
    (person, email) => new
    {
        person.LastName,
        person.FirstName,
        email.Email
    }
).ToList();

var customerNames = context.Customers
.Where(c => c.CustomerId != null)
.Join(context.People,
    c => c.PersonId,
    p => p.BusinessEntityId,
    (c, p) => new
    {
        c.CustomerId,
        p.LastName,
        p.FirstName
    }
).ToList();


var ordersWithCustomerName = context.salesOrderHeaders
.Join(context.Customers,
    order => order.CustomerID,
    customer => customer.CustomerId,
    (order, customer) => new { order, customer }
)
.Where(x => x.customer.PersonId != null)
.Join(context.People,
    x => x.customer.PersonId,
    person => person.BusinessEntityId,
    (x, person) => new
    {
        x.order.SalesOrderId,
        x.order.OrderDate,
        x.order.TotalDue,
        CustomerName = person.FirstName + " " + person.LastName
    }
).ToList();

var productsWithCategory = context.Products
.Where(p => p.ProductSubcategoryID != null)
.Join(context.productSubcategories,
    product => product.ProductSubcategoryID,
    subcat => subcat.ProductSubcategoryID,
    (product, subcat) => new { product, subcat }
).Join(context.productSubcategories,
    ps => ps.subcat.ProductCategoryID,
    cat => cat.ProductCategoryID,
    (ps, cat) => new
    {
        productName = ps.product.Name,
        ps.product.ListPrice,
        SubcategoryName = ps.subcat.Name,
        CategoryName = cat.Name
    }
).ToList();

foreach (var p in emails)
{
    Console.WriteLine($"ProcutWithModel:  {p.FirstName} ----- {p.LastName}");
}