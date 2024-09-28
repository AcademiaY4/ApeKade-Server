using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace apekade.Middleware
{
    public class EndpointException
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<EndpointException> _logger;

        public EndpointException(RequestDelegate next, ILogger<EndpointException> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            // Ensure response has not started before modifying headers
            if (!context.Response.HasStarted)
            {
                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    await HandleNotFoundAsync(context);
                }
                else if (context.Response.StatusCode == StatusCodes.Status405MethodNotAllowed)
                {
                    await HandleMethodNotAllowedAsync(context);
                }
            }
            else
            {
                _logger.LogWarning("Response has already started. Skipping custom error handling.");
            }
        }

        private Task HandleNotFoundAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var response = new
            {
                Status = false,
                Code = 404,
                Message = "The requested resource was not found.",
                Data = new { }
            };

            return context.Response.WriteAsJsonAsync(response);
        }

        private Task HandleMethodNotAllowedAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var response = new
            {
                Status = false,
                Code = 405,
                Message = "The requested method is not allowed.",
                Data = new { }
            };

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
