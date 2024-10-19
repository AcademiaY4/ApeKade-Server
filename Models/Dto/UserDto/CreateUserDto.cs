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
    public string Telephone { get; set; }
    public int Age { get; set; }
    public string District { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Company { get; set; }
    public string ShopName { get; set; }
    public string ShopDescription { get; set; }

}
