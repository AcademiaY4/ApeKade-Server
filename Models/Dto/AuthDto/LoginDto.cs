#nullable disable
namespace apekade.Models.Dto.AuthDto;

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
