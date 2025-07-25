using System.Text.Json;
using AdventureWorksAPI.Middlewares.ErrorHandling;

namespace AdventureWorksAPI.Middlewares.SimpleLogging
{
    public class SimpleExceptionsHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SimpleExceptionsHandlingMiddleware> _logger;

        public SimpleExceptionsHandlingMiddleware(RequestDelegate next, ILogger<SimpleExceptionsHandlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = new { Message = "An error occurred.", ErrorCode = "UnexpectedError" };
            int statusCode = StatusCodes.Status500InternalServerError;

            switch (ex)
            {
                case ValidationExceptions vex:
                    statusCode = StatusCodes.Status400BadRequest;
                    response = new { Message = vex.Message, ErrorCode = "ValidationError" };
                    _logger.LogWarning(ex, "Validation error: {Message}", vex.Message);
                    break;
                case NotFoundException nex:
                    statusCode = StatusCodes.Status404NotFound;
                    response = new { Message = nex.Message, ErrorCode = "NotFoundError" };
                    _logger.LogInformation(ex, "Not found: {Message}", nex.Message);
                    break;

                default:
                    _logger.LogError(ex, "Unexpected error: {Message}", ex.Message);
                    break;
            }

                context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}