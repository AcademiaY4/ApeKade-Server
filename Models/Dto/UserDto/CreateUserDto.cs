#nullable disable
using System;

namespace apekade.Models.Dto.UserDto;

public class CreateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } 
    public string Role { get; set; }

}
