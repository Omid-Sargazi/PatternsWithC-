using System.Text.Json;
using Azure.Identity;

namespace AdventureWorksAPI.Middlewares.AuthorizationHandlers
{
    public class AuthorizationExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthorizationExceptionMiddleware> _logger;
        public AuthorizationExceptionMiddleware(RequestDelegate next, ILogger<AuthorizationExceptionMiddleware> logger)
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
            catch (AuthenticationFailedException ex)
            {

                _logger.LogWarning(ex, "Authorization failed: {Message}", ex.Message);
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";
                var response = new { Message = "You do not have permission to perform this action." };
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error: {Message}", ex.Message);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var response = new { Message = "An unexpected error occurred." };
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}