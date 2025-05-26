using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServicesInProjects.Data;
using ServicesInProjects.Middlewares;
using ServicesInProjects.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddTransient<IGreetingService, GreetingService>();
        builder.Services.AddScoped<ITodoService, TodoService>();
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<ITodoRepository, TodoRepository>();
        builder.Services.AddScoped<ITodoService, TodoService>();
        builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
        builder.Services.AddScoped<IProjectService, ProjectService>();
        builder.Services.AddSingleton<IValidationService, ValidationService>();
        builder.Services.AddControllers();

        var app = builder.Build();
        app.UseMiddleware<CustomHeaderMiddleware>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();
        app.MapControllers();



        app.Run();
    }
}


