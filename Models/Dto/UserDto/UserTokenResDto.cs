namespace apekade.Models.Dto.UserDto;

public class UserTokenResDto
{
    public required UserResDto User { get; set; }
    public required string Token { get; set; }
}