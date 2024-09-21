using System.ComponentModel.DataAnnotations;
using apekade.Enums;

namespace apekade.Models.Dto.UserDto;

public class UserResDto
{
    [Required]
    public required string FirstName { get; set; }
    public string? LastName { get; set; }

    [EmailAddress]
    [Required]
    public required string Email { get; set; }

    [Required]
    public Role Role { get; set; }
}