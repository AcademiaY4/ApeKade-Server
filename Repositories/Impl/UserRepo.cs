using MongoDB.Driver;
using apekade.Models;
using apekade.Enums;

namespace apekade.Repositories;

public class UserRepo : IUserRepo
{
    private readonly IMongoCollection<User> _users;
    public UserRepo(IMongoDatabase database)
    {
        _users = database.GetCollection<User>("Users");
    }
    // method to save a new user
    public async Task CreateNewUser(User user)
    {
        await _users.InsertOneAsync(user);
    }

    //method to check if user existing
    public async Task<User?> GetUserByEmail(string email)
    {
        return await _users.Find(user => user.Email == email).FirstOrDefaultAsync();
    }

    //method to get user existing by id
    public async Task<User?> GetUserById(string Id)
    {
        return await _users.Find(user => user.Id == Id).FirstOrDefaultAsync();
    }

    //method to check if a user exists by email and role
    public async Task<List<User>> GetUsersByRole(string role)
    {
        return await _users.Find(user => user.Role.ToString().Equals(role, StringComparison.OrdinalIgnoreCase))
                           .ToListAsync();
    }

    //method to check if a user exists by email and role
    public async Task<User?> GetUserByEmailAndRole(string email, string role)
    {
        return await _users.Find(user => user.Email == email && user.Role.ToString() == role).FirstOrDefaultAsync();
    }

    // Method to get all users
    public async Task<List<User>> GetAllUsers()
    {
        return await _users.Find(user => true).ToListAsync();
    }

    // Method to update user profile
    public async Task UpdateProfile(User user)
    {
        await _users.ReplaceOneAsync(u => u.Id == user.Id, user);
    }

    //method to add rating for  vendor
    public async Task AddVendorRating(User vendor)
    {
        await _users.ReplaceOneAsync(u=>u.Id == vendor.Id,vendor);
    }

    // Method to approve customer accounts
    public async Task ApproveUserAccount(string userId)
    {
        var update = Builders<User>.Update.Set(u => u.Status, Models.Enums.Status.ACTIVE);
        await _users.UpdateOneAsync(u => u.Id == userId, update);
    }

    // Method to deactivate a user account
    public async Task DeactivateAccount(string userId)
    {
        var update = Builders<User>.Update.Set(u => u.Status, Models.Enums.Status.DEACTIVATED);
        await _users.UpdateOneAsync(u => u.Id == userId, update);
    }

    // Method to reactivate a user account
    public async Task ReactivateAccount(string userId)
    {
        var update = Builders<User>.Update.Set(u => u.Status, Models.Enums.Status.ACTIVE);
        await _users.UpdateOneAsync(u => u.Id == userId, update);
    }
    //mehtod to delete user
    public async Task DeleteUser(string userId)
    {
        await _users.DeleteOneAsync(user => user.Id == userId);
    }

    public async Task<User?> GetUserByIdAndRole(string Id, string role)
    {
        return await _users.Find(user => user.Id == Id && user.Role.ToString() == role).FirstOrDefaultAsync();
    }
}