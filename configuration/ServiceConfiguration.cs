using System.Reflection;
using apekade.Helpers;
using apekade.Models.Filter;
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
        services.AddControllers(
            // add custom exception filter
            // cfg=>{
            //     cfg.Filters.Add(typeof(ExceptionFilter));
            // }
        ).ConfigureApiBehaviorOptions(options =>{
            //disables the default behaviour of the [ApiController] 
             options.SuppressModelStateInvalidFilter = true;
        }).AddFluentValidation(v=>{
            v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        });

        // Add services to the container.
        services.AddEndpointsApiExplorer();

        //Add Automapper configs
        services.AddAutoMapper(typeof(Program).Assembly);

        // Register services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IBuyerService, BuyerService>();
        services.AddScoped<ICsrService, CsrService>();
        services.AddScoped<IVendorService, VendorService>();
        services.AddScoped<IStockService, StockService>();
        services.AddScoped<ICategoryService, CategoryService>();

        // register helpers with DI
        services.AddScoped<JwtHelper>();

        // register repositories
        services.AddScoped<IUserRepo,UserRepo>();

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
