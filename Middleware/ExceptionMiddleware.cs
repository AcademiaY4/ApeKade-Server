using System;
using System.Net;
using apekade.Models.Response;

namespace apekade.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next){
       _next = next;
    }
    public async Task InvokeAsync(HttpContext context){
         try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            var error = new ErrorRes{
                Code = context.Response.StatusCode,
                Status = false,
                Data= new {},
                Message = e.Message
            };
            await context.Response.WriteAsync(error.ToString());
        }
    }

}
