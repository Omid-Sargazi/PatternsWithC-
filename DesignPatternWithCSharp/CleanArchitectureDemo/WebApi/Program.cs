using Application.Interfaces;
using Infrastructure.Repositories;
using WebApi.Middlewares;
using WebApi.Presenters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<IRegisterUserOutput, WebApiRegisterUserPresenter>();
builder.Services.AddScoped<ILoginUserOutput, WebApiLoginUserPresenter>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

var app = builder.Build();
app.UseMiddleware<MyCustomMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapGet("/throw-test", () =>
{
    throw new InvalidOperationException("this is an error for testing");
});
// app.UseMiddleware<RequestTimingMiddleware>();
// app.UseMiddleware<JwtValidationMiddleware>();
// app.UseMiddleware<FirstMiddleware>();
// app.UseMiddleware<LoggingMiddleware>();
// app.UseMiddleware<TerminalMiddleware>();


app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();

