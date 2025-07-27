using System.Text.Json;

namespace AdventureWorksAPI.CleanMiddleware
{
    public class ExceptionHandlingMiddlewaree
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddlewaree> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionHandlingMiddlewaree(RequestDelegate next, ILogger<ExceptionHandlingMiddlewaree> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error dont controller");
                context.Response.ContentType = "appplication/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var resposne = _env.IsDevelopment() ?
                new { statusCode = 500, message = ex.Message, }
                : new { statusCode = 500, message = "Internal server error occured" };

                var json = JsonSerializer.Serialize(resposne);
                await context.Response.WriteAsync(json);
            }
        }
    }
}