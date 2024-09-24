using MongoDB.Driver;
using apekade.Models;
using apekade.Enums;

namespace apekade.Repositories;

public class UserRepository
{
    private readonly IMongoCollection<User> _users;
    public UserRepository(IMongoDatabase database)
    {
        _users = database.GetCollection<User>("Users");
    }
    // method to save a new user
    public async Task Save(User user){
        await _users.InsertOneAsync(user);
    }

    //method to check if user existing
    public async Task<User?> GetUserByEmail(string email){
        return await _users.Find(user => user.Email == email).FirstOrDefaultAsync();
    }

    //method to check if a user exists by email and role
    public async Task<User?> GetUserByEmailAndRole(string email , string role){
        return await _users.Find(user=> user.Email ==email && user.Role.ToString() == role).FirstOrDefaultAsync();
    }

}