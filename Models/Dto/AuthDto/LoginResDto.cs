#nullable disable
using System;

namespace apekade.Models.Dto.AuthDto;

public class LoginResDto
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}
