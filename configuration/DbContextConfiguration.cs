using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using apekade.Data;

namespace apekade.Configuration;

public static class DbContextConfiguration
{
    public static void ConfigureDbContextServices(IServiceCollection services, IConfiguration configuration)
    {
        // Register the DbSettings configuration
        services.Configure<DbSettings>(configuration.GetSection(nameof(DbSettings)));

        // Register the MongoDB DbContext
        // service is created once for all.
        services.AddSingleton(provider =>
        {
            var dbSettings = provider.GetRequiredService<IOptions<DbSettings>>() ?? throw new InvalidOperationException("MongoDbSettings is not configured properly");

            // Initialize DbContext with the DbSettings
            return new DbContext(dbSettings);
        });

        // service is created once per HTTP request in web applications.
        services.AddScoped(sp =>
        {
            var settings = sp.GetRequiredService<IOptions<DbSettings>>().Value;
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(settings.DatabaseName);
        });
    }
}
