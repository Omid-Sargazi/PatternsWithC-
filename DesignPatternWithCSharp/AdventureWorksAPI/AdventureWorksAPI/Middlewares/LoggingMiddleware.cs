namespace AdventureWorksAPI.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // context.Response.Headers.Add("X-Logging-Middleware", "activated");
            _logger.LogInformation("Incoming request: [Method],[Path]", context.Request.Method, context.Request.Path);
            await _next(context);
            _logger.LogInformation("Outgoing response: {StatusCode}", context.Response.StatusCode);
        }
    }
}