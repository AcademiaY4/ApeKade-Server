using System;
using apekade.Models.Response;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
namespace apekade.Middleware;

public class ValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ValidationMiddleware> _logger;

    public ValidationMiddleware(RequestDelegate next, ILogger<ValidationMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Proceed with the next middleware in the pipeline
        await _next(context);

        // Check if there are validation errors
        if (!context.Response.HasStarted && context.Response.StatusCode == 400 && context.Items.ContainsKey("ModelState"))
        {
            var modelState = context.Items["ModelState"] as ModelStateDictionary;
            if (modelState != null && !modelState.IsValid)
            {
                var firstError = modelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .FirstOrDefault();

                var errorResponse = new ErrorRes{
                    Code = 400,
                    Status = false,
                    Message = "Validation errors",
                    Data = new { Error = firstError }
                };

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(errorResponse.ToString());
            }
        }
    }
}
