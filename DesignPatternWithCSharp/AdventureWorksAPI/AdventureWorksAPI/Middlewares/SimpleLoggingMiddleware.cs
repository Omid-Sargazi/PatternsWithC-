using Microsoft.AspNetCore.Identity.Data;

namespace AdventureWorksAPI.Middlewares
{
    public class SimpleLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SimpleLoggingMiddleware> _logger;
        public SimpleLoggingMiddleware(RequestDelegate next, ILogger<SimpleLoggingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Incoming Request:{Method} {Path}", context.Request.Method, context.Request.Path);
            await _next(context);
        }

        
    }
}