using AdventureWorksAPI.Middlewares;
using AdventureWorksAPI.Models;
using AdventureWorksAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdventureWorks2019Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<CountRequest>();

app.UseWhen(context => context.Request.Path.StartsWithSegments("/logging"),
    builder=>
    {
        builder.UseMiddleware<LoggingMiddleware>();
    }
);

app.UseMiddleware<RequestTimeMiddleware>();

if (app.Environment.IsDevelopment())
{
    // app.UseDeveloperExceptionPage();
}
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseExceptionHandler("/Erorr");


app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
