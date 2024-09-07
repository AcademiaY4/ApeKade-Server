public static class ServiceConfiguration
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        // Add controllers
        services.AddControllers();

        // Configure Swagger
        SwaggerConfiguration.ConfigureSwaggerServices(services);

        // Configure DbContext
        DbContextConfiguration.ConfigureDbContextServices(services, configuration);

        // Configure Identity and Authorization

        // Register services
        // services.AddScoped<IEmpService, EmpService>();

        //configure JWT
        JwtConfiguration.ConfigureJwtServices(services,configuration);

        // Configure CORS
        CorsConfiguration.ConfigureCorsServices(services);
    }
}
