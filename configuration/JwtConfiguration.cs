public static class JwtConfiguration{
     public static void ConfigureJwtServices(IServiceCollection services, IConfiguration configuration)
    {
        // Register JWT settings from "AppSettings"
        var jwtSettings = configuration.GetSection("AppSettings").Get<JWTSettings>();
        services.AddSingleton(jwtSettings);

        // If you have any additional JWT-related services or middleware, you can configure them here.
        // Example: services.AddAuthentication(...).AddJwtBearer(...);
    }
}