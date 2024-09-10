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
}