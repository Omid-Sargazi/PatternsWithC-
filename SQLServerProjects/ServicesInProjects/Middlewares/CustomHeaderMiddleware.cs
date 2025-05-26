namespace ServicesInProjects.Middlewares
{
    public class CustomHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add("X-Custom-Header", "This is a custom header from Middleware");
            await _next(context);
        }
    }
}