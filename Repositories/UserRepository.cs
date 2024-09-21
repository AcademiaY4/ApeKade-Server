using MongoDB.Driver;
using apekade.Models;

namespace apekade.Repositories;

public class UserRepository
{
    private readonly IMongoCollection<User> _usersCollection;

    public UserRepository(IMongoDatabase database)
    {
        _usersCollection = database.GetCollection<User>("Users");
    }

    public async Task Save(User user)
    {
        await _usersCollection.InsertOneAsync(user);
    }
}