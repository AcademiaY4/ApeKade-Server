using Microsoft.Extensions.Options;
using MongoDB.Driver;
using apekade.Models;

namespace apekade.Data;
public class DbContext{
    private readonly IMongoDatabase _database;

    public DbContext(IOptions<DbSettings> options){
        var settings = options.Value;
        var client = new MongoClient(settings.ConnectionString);
        _database = client.GetDatabase(settings.DatabaseName);
    }
    //include all the mongo collections 
    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    public IMongoCollection<Stock> Stocks => _database.GetCollection<Stock>("Stocks");
    public IMongoCollection<Category> Categories => _database.GetCollection<Category>("Categories");
    public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
    public IMongoCollection<Notification> Notifications => _database.GetCollection<Notification>("Notifications");
}