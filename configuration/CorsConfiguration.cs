using Microsoft.Extensions.DependencyInjection;
namespace apekade.Configuration;

public static class CorsConfiguration
{
    public static void ConfigureCorsServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            // options.AddPolicy("AllowAll", builder =>
            // {
            //     builder.AllowAnyOrigin()
            //            .AllowAnyHeader()
            //            .AllowAnyMethod();
            // });
            options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins("http://localhost:3000","http://localhost:5173","https://apekade-admin.netlify.app")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });
    }
}
