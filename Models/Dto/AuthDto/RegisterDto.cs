#nullable disable
namespace apekade.Models.Dto.AuthDto;

public class RegisterDto
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
}
