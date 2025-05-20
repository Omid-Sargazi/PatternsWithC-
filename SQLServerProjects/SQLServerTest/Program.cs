using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

string masterConnectionString = "Server=localhost;Database=master;User Id=sa;Password=15935755Omid$@;Encrypt=False;";
        // رشته اتصال برای دیتابیس TestDB
        string connectionString = "Server=localhost;Database=TestDB;User Id=sa;Password=15935755Omid$@;Encrypt=False;";

        try
        {
            // بررسی و ایجاد دیتابیس TestDB
            using (SqlConnection connection = new SqlConnection(masterConnectionString))
            {
                connection.Open();
                Console.WriteLine("اتصال به دیتابیس master برقرار شد.");

                // بررسی وجود دیتابیس و ایجاد آن در صورت عدم وجود
                string checkDbQuery = "IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'TestDB') CREATE DATABASE TestDB";
                using (SqlCommand command = new SqlCommand(checkDbQuery, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("دیتابیس TestDB بررسی یا ایجاد شد.");
                }
            }

            // اتصال به دیتابیس TestDB و ایجاد جدول
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("اتصال به دیتابیس TestDB برقرار شد.");

                // ایجاد جدول Users (اگر وجود نداشته باشد)
                string createTableQuery = @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
                                           CREATE TABLE Users (Id INT PRIMARY KEY, Name NVARCHAR(50))";
                using (SqlCommand command = new SqlCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("جدول Users بررسی یا ایجاد شد.");
                }

                // درج داده نمونه
                string insertQuery = "INSERT INTO Users (Id, Name) VALUES (1, N'امید')";
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    insertCommand.ExecuteNonQuery();
                    Console.WriteLine("کاربر با موفقیت اضافه شد!");
                }

                // خواندن داده‌ها
                string selectQuery = "SELECT Id, Name FROM Users";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        Console.WriteLine("داده‌های جدول Users:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("خطا: " + ex.Message);
        }
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
