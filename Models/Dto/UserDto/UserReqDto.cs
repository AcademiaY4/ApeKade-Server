using System.ComponentModel.DataAnnotations;
using apekade.Enums;

namespace apekade.Models.Dto.UserDto;

public class UserReqtDto
{
    [Required]
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
    
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    
    [Required]
    public required string Password { get; set; }
    
    [Required]
    public Role Role { get; set; }
}