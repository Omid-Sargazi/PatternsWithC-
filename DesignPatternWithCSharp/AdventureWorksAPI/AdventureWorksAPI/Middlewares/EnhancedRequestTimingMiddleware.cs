namespace AdventureWorksAPI.Middlewares
{
    public class EnhancedRequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly object _fileLock = new object();
        private readonly string _logFilePath2;


        public EnhancedRequestTimingMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _logFilePath2 = Path.Combine(env.ContentRootPath, "logs", "request_log2.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(_logFilePath2));

        }

        public async Task InvokeAsync(HttpContext context)
        {
            var startTime = DateTime.UtcNow;

            var ipAddress = context.Connection.RemoteIpAddress?.ToString() ?? "UnKnown";
            var userAgent = context.Request.Headers.TryGetValue("User-Agent", out var ua) ? ua.ToString() : "none";
            var statusCode = context.Response.StatusCode;



            var duration = DateTime.UtcNow - startTime;

            var logEntry = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}|" +
            $"{context.Request.Method} {context.Request.Path}  |" +
            $"IP:{ipAddress}  |" +
            $"Duration: {duration.TotalMilliseconds}ms |" +
            $"Status: {statusCode}" +
            $"User-Agent: {userAgent}{Environment.NewLine}";
            _next(context);

        }

        private async Task WriteLogAsync(string logEntry)
        {
            await Task.Run(() =>
            {
                lock (_fileLock)
                {
                    File.AppendAllText(_logFilePath2, logEntry);
                }
            });
        }
    }

}

