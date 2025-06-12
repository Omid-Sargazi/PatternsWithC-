using InterviewQuestions.Day01;
using InterviewQuestions.Day02;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IGreetingService, GreetingService>();
builder.Services.AddTransient<ITimeService, TimeService>();
builder.Services.AddScoped<ILoggerService, LoggerService>();
builder.Services.AddScoped<BusinessService>();
builder.Services.AddScoped<IAppInfoService, AppInfoService>();
builder.Services.AddHttpClient<IGitHubService, GitHubService>();
builder.Services.AddScoped<IGitHubService, GitHubService>();
builder.Services.AddScoped<IProcessNotifier, ProcessBusinessLogic>();


builder.Services.AddOpenApi();
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// app.UseHttpsRedirection();



app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
