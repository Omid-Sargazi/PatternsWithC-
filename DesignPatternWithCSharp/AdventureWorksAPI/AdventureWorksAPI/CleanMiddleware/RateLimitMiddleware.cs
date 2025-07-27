namespace AdventureWorksAPI.CleanMiddleware
{
    public class RateLimitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RateLimitMiddleware> _logger;
        public RateLimitMiddleware(RequestDelegate next, ILogger<RateLimitMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        private static readonly Dictionary<string, RateLimitEntry> _clients = new();
        private const int LIMIT = 5;
        private static readonly TimeSpan WINDOW = TimeSpan.FromMinutes(1);


        public async Task InvokeAsync(HttpContext context)
        {
            var userId = context.Items["UserId"] as string;
            if (userId == null)
            {
                await _next(context);
                return;
            }

            var now = DateTime.UtcNow;
            lock (_clients)
            {
                if (!_clients.TryGetValue(userId, out var entry))
                {
                    _clients[userId] = new RateLimitEntry
                    {
                        Count = 1,
                        ExpireAt = now.Add(WINDOW)
                    };
                }
                else
                {
                    if (entry.ExpireAt < now)
                    {
                        // Reset window
                        entry.Count = 1;
                        entry.ExpireAt = now.Add(WINDOW);
                    }
                    else if (entry.Count < LIMIT)
                    {
                        entry.Count++;
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                        context.Response.Headers["Retry-After"] = (entry.ExpireAt - now).TotalSeconds.ToString("F0");
                        _logger.LogWarning($"Rate limit exceeded for user {userId}");
                        return;
                    }
                }
            }
        }


        private class RateLimitEntry
        {
            public int Count { get; set; }
            public DateTime ExpireAt { get; set; }
        }
    }
    
    
}