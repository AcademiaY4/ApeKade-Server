#nullable disable
using System;

namespace apekade.Models.Dto.UserDto;

public class ChangePasswordDto
{
    // public string UserId { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}
