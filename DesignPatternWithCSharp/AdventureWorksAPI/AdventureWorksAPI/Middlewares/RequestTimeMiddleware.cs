namespace AdventureWorksAPI.Middlewares
{
    public class RequestTimeMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var start = DateTime.UtcNow;
            await _next(context);

            var duration = DateTime.UtcNow - start;
            Console.WriteLine($"Request took {duration.TotalMilliseconds} ms");
        }
    }
}