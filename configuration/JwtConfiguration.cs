using System.Text;
using apekade.Models.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;

namespace apekade.Configuration;

public static class JwtConfiguration
{
    public static void ConfigureJwtServices(IServiceCollection services, IConfiguration configuration)
    {
        // Register JWT settings from "AppSettings"
        var key = Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value!);

        // If you have any additional JWT-related services or middleware, you can configure them here.
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            options.Events = new JwtBearerEvents
            {
                OnChallenge = context =>
                {
                    context.HandleResponse(); // Suppress the default response

                    // Create the custom response
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json";
                    var response = new ErrorRes
                    {
                        Status = false,
                        Code = 401,
                        Message = string.IsNullOrEmpty(context.Request.Headers.Authorization)
                                  ? "Authorization header is missing."
                                  : "Invalid or token timeout.",
                        Data = new { }
                    };
                    return context.Response.WriteAsync(response.ToString());
                    // return context.Response.WriteAsync(JsonSerializer.Serialize(response));
                },
                OnForbidden = context =>
               {
                   context.Response.StatusCode = 403;
                   context.Response.ContentType = "application/json";
                   var response = new ErrorRes
                   {
                       Status = false,
                       Code = 403,
                       Message = "You do not have access to this resource.",
                       Data = new { }
                   };
                   return context.Response.WriteAsync(response.ToString());
                   //    return context.Response.WriteAsync(JsonSerializer.Serialize(response));
               }
            };
        });
        // Configure Swagger to handle JWT Bearer token
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Description = """Standard Authorization header using the Bearer scheme. Example: "Bearer {token}" """,
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Name = "Authorization",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
            });
            c.OperationFilter<SecurityRequirementsOperationFilter>();
        });
    }
}