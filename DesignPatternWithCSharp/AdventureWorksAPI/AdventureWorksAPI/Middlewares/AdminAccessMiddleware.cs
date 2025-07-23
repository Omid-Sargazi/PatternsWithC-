namespace AdventureWorksAPI.Middlewares
{
    public class AdminAccessMiddleware
    {
        private readonly RequestDelegate _next;

        public AdminAccessMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/admin"))
            {
                if (context.Request.Headers.TryGetValue("X-admin", out var adminHeader) ||
                    bool.TryParse(adminHeader, out var isAdmin) || !isAdmin
                )
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("forbidden");
                    return;
                }
            }
            await _next(context);
        }
    }
}