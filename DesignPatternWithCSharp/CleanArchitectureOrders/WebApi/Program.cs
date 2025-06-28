using Application.Interfaces;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();


var app = builder.Build();

// app.UseSwagger();
// app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();