namespace WebApi.Middlewares
{
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;
        public MyCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Before COnrorller");
            _next(context);
            Console.WriteLine("After COnrorller");
        }
    }
}