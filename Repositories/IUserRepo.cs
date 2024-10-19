using System;
using apekade.Models;
using apekade.Models.Dto.AuthDto;

namespace apekade.Repositories;

public interface IUserRepo
{
    Task CreateNewUser(User user);
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserById(string Id);
    Task<User?> GetUserByIdAndRole(string Id,string role);
    Task<List<User>> GetUsersByRole(string role);
    Task<User?> GetUserByEmailAndRole(string email, string role);
    Task<List<User>> GetAllUsers();
    Task UpdateProfile(User user);
    Task AddVendorRating(User vendor);
    Task ApproveUserAccount(string userId);
    Task DeactivateAccount(string userId);
    Task ReactivateAccount(string userId);
    Task DeleteUser(string userId);
    Task<List<Rating>> GetReviewsByUserId(string userId);
}
