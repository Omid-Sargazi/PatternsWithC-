using System.Text.Json;

namespace AdventureWorksAPI.Middlewares.ErrorHandling
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IWebHostEnvironment env)
        {
            _env = env;
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

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new ErrorResponse();
            int statusCode;

            switch (exception)
            {
                case ValidationExceptions vex:
                    statusCode = StatusCodes.Status400BadRequest;
                    response.Message = vex.Message;
                    response.ErrorCode = "ValidationError";
                    _logger.LogWarning(exception, "Validation Error occured {Message}", vex.Message);
                    break;

                case NotFoundException nex:
                    statusCode = StatusCodes.Status404NotFound;
                    response.Message = nex.Message;
                    response.ErrorCode = "NotFoundError";
                    _logger.LogInformation(exception, "Resource Not Found{Message}", nex.Message);
                    break;

                case DatabaseException dex:
                    statusCode = StatusCodes.Status500InternalServerError;
                    response.Message = "A database error occurred. Please try again later.";
                    response.ErrorCode = "DatabaseError";
                    _logger.LogError(exception, "Database error: {Message}", dex.Message);
                    break;

                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    response.Message = "An unexpected error occurred. Please try again later.";
                    response.ErrorCode = "UnexpectedError";
                    _logger.LogError(exception, "Unexpected error: {Message}", exception.Message);
                    break;
            }

            if (_env.IsDevelopment())
            {
                response.Details = exception.StackTrace;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}