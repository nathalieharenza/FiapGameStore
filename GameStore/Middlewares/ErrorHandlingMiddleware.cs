using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace GameStore.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger logger)
        {
            var errorDetails = new
            {
                message = "Ocorreu um erro inesperado.",
                detail = exception.Message,
                path = context.Request.Path,
                method = context.Request.Method,
                status = (int)HttpStatusCode.InternalServerError,
                timestamp = DateTime.UtcNow
            };

            logger.LogError(exception, "[{Message} | Path: {Path} | Method: {Method}", exception.Message, context.Request.Path, context.Request.Method);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorDetails));
        }
    }
}

