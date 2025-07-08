namespace WebApi.Middlewares
{

    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;

        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Use 1");
            await _next(context);
            Console.WriteLine("Use 1 - End");
        }
    }
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"got requested:{context.Request.Path}");
            await _next(context);
            Console.WriteLine($"sent response:{context.Response.StatusCode}");

        }
    }

    public class TerminalMiddleware
    {
        private readonly RequestDelegate _next;
        public TerminalMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Hello from Run");
        }

    }
}