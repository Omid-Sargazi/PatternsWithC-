using Microsoft.Extensions.Caching.Memory;

namespace WebApi.Middlewares
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;
        private readonly int _limit = 5;
        private readonly TimeSpan _period = TimeSpan.FromSeconds(10);

        public RateLimitingMiddleware(RequestDelegate next, IMemoryCache cache)
        {
            _next = next;
            _cache = cache;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress?.ToString();
            if (!string.IsNullOrWhiteSpace(ip))
            {
                await _next(context);
                return;
            }

            var cacheKey = $"rl_{ip}";
            var requestCount = _cache.GetOrCreate(cacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = _period;
                return 0;
            });

            if ((int)requestCount >= _limit)
            {
                context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                await context.Response.WriteAsync("Too amny requests. Try agin later.");
                return;
            }

            _cache.Set(cacheKey, (int)requestCount + 1, _period);
            await _next(context);
        }
    }
}