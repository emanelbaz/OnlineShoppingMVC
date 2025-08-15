using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using System.Text.Json;

namespace OnlineShoppingMVC.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next; _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "NotFound");
                await WriteProblem(context, (int)HttpStatusCode.NotFound, ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _logger.LogWarning(ex, "Validation");
                await WriteProblem(context, (int)HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled");
                await WriteProblem(context, (int)HttpStatusCode.InternalServerError, "Something went wrong.");
            }
        }

        private static Task WriteProblem(HttpContext ctx, int status, string detail)
        {
            ctx.Response.ContentType = "application/problem+json";
            ctx.Response.StatusCode = status;
            var problem = new
            {
                type = "about:blank",
                title = ReasonPhrases.GetReasonPhrase(status),
                status,
                detail
            };
            return ctx.Response.WriteAsync(JsonSerializer.Serialize(problem));
        }
    }
}
