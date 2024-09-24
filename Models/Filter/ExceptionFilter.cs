using System;
using apekade.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace apekade.Models.Filter;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var httpContext = context.HttpContext;
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var error = new ErrorRes
        {
            Code = httpContext.Response.StatusCode,
            Status = false,
            Data = new { },
            Message = context.Exception.Message
        };
        context.Result = new JsonResult(error)
        {
            StatusCode = 500,
            ContentType = "application/json"
        };
    }
}
