using Microsoft.AspNetCore.Mvc;

namespace apekade.Controllers;

[Route("api/[controller]")]
[ApiController]
// [Authorize]
public class StatusController : ControllerBase
{

    [HttpGet]
    public IActionResult GetServerStatus()
    {
        var response = new ApiRes<object>{
            Status = "Success",
            Code= 200,
            Data = new { Message = "Server Online" }
        };
        return Ok(response);

    }
}