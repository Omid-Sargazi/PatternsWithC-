namespace AdventureWorksAPI.Middlewares
{
    public class RequestTimeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _logFilePath;
        private readonly object _fileLock = new object();
        public RequestTimeMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _logFilePath = Path.Combine(env.ContentRootPath, "request_log.txt");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var start = DateTime.UtcNow;
            await _next(context);

            var duration = DateTime.UtcNow - start;
            var logEntry = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} | {context.Request.Method} {context.Request.Path} | " +
                      $"Duration: {duration.TotalMilliseconds}ms | Status: {context.Response.StatusCode}{Environment.NewLine}";

            lock (_fileLock)
            {
                File.AppendAllText(_logFilePath, logEntry);
            }

            Console.WriteLine($"Request took {duration.TotalMilliseconds} ms");
        }
    }
}