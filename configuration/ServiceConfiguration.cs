using System.Reflection;
using apekade.Dto.UserDto;
using apekade.Helpers;
using apekade.Repositories;
using apekade.Services;
using apekade.Services.Impl;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace apekade.Configuration;

public static class ServiceConfiguration
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        // Add controllers
        services.AddControllers();

        // Add services to the container.
        services.AddEndpointsApiExplorer();

        //Add Automapper configs
        services.AddAutoMapper(typeof(Program).Assembly);

        // Register services
        services.AddScoped<IUserService, UserService>();

        // register helpers with DI
        services.AddScoped<GenerateJwtToken>();

        // register repositories
        services.AddScoped<UserRepository>();

        // Register IMongoClient
        services.AddSingleton<IMongoClient>(sp =>
        {
            var settings = sp.GetRequiredService<IOptions<DbSettings>>().Value;
            return new MongoClient(settings.ConnectionString);
        });

        // Configure Swagger
        SwaggerConfiguration.ConfigureSwaggerServices(services);

        // Configure DbContext
        DbContextConfiguration.ConfigureDbContextServices(services, configuration);

        // Configure Identity and Authorization

        //configure JWT
        JwtConfiguration.ConfigureJwtServices(services, configuration);

        // Configure CORS
        CorsConfiguration.ConfigureCorsServices(services);
    }
}
