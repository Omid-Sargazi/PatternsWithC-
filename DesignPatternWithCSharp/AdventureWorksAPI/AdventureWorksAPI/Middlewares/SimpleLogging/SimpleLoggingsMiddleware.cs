namespace AdventureWorksAPI.Middlewares.SimpleLogging
{
    public class SimpleLoggingsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SimpleLoggingsMiddleware> _logger;
        public SimpleLoggingsMiddleware(RequestDelegate next, ILogger<SimpleLoggingsMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);
            await _next(context);

        }
    }
}