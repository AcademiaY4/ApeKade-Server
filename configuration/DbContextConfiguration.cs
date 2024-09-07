using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
public static class DbContextConfiguration
{
    public static void ConfigureDbContextServices(IServiceCollection services, IConfiguration configuration)
    {
         // Register the DbSettings configuration
         services.Configure<DbSettings>(configuration.GetSection(nameof(DbSettings)));

         // Register the MongoDB DbContext
        //  services.AddSingleton<DbContext>();
        
        services.AddSingleton(provider =>{
            var dbSettings = provider.GetService<IOptions<DbSettings>>() ?? throw new InvalidOperationException("MongoDbSettings is not configured properly");

            // Initialize DbContext with the DbSettings
             return new DbContext(dbSettings);
        });
    }
}
