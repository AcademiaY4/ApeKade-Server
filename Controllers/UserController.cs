using Microsoft.AspNetCore.Mvc;
using apekade.Enums;
using apekade.Services;
using apekade.Dto.UserDto;

namespace apekade.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase{
    private readonly IUserService _userService;

    public UserController(IUserService userService){
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserReqtDto userReqtDto){

        var response = await _userService.CreateNewUser(userReqtDto);
        return Ok(response);
    }
}