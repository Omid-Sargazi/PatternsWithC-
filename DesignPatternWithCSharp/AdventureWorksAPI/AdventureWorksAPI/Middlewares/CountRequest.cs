namespace AdventureWorksAPI.Middlewares
{
    public class CountRequest
    {
        private readonly RequestDelegate _next;
        private static int _totalRequests = 0;
        private static readonly object _lock = new object();
        public CountRequest(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            int currentCount;

            lock (_lock)
            {
                currentCount = ++_totalRequests;
            }
           Console.WriteLine($"درخواست ورودی #{currentCount} - مسیر: {context.Request.Path}");
            _next(context);
            Console.WriteLine($"پردازش درخواست #{currentCount} تکمیل شد");
        }
    }
}