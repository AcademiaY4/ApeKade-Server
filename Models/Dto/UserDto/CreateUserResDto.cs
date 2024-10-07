#nullable disable
using System;

namespace apekade.Models.Dto.UserDto;

public class CreateUserResDto
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    // For customer account approval by CSR/Admin
    public bool IsApproved { get; set; }
    // Can be 'PENDING', 'ACTIVE', or 'DEACTIVATED'
    public string Status { get; set; }
    public string DateCreated { get; set; }
    public string Telephone { get; set; }
    public int Age { get; set; }
    public string District { get; set; }
    public string Province { get; set; }
    public string City { get; set; }

}
