using Microsoft.AspNetCore.Mvc;
using apekade.Dto;
using Microsoft.AspNetCore.Authorization;

namespace apekade.Controllers;

[Route("api/[controller]")]
[ApiController]
// [Authorize]
public class TestController : ControllerBase
{

    [HttpGet]
    public IActionResult GetServerStatus()
    {
        var response = new ApiRes<object>{
            Status = true,
            Code= 200,
            Data = new { Message = "Server Online" }
        };
        return Ok(response);

    }
    // Only SuperAdmin can access this endpoint
    [Authorize(Roles = "SUPER_ADMIN")]
    [HttpGet("superadmin")]
    public IActionResult SuperAdminOnly()
    {
        return Ok("Only SuperAdmin can access this.");
    }

    // Only Seller can access this endpoint
    [Authorize(Roles = "SELLER")]
    [HttpGet("seller")]
    public IActionResult SellerOnly()
    {
        return Ok("Only Sellers can access this.");
    }

    // Only Buyer can access this endpoint
    [Authorize(Roles = "BUYER")]
    [HttpGet("buyer")]
    public IActionResult BuyerOnly()
    {
        return Ok("Only Buyers can access this.");
    }

    // Both Seller and Buyer can access this endpoint
    [Authorize(Roles = "SELLER,BUYER")]
    [HttpGet("seller-buyer")]
    public IActionResult SellerAndBuyerAccess()
    {
        return Ok("Both Sellers and Buyers can access this.");
    }

    // Any authenticated user can access this endpoint
    [Authorize]
    [HttpGet("common")]
    public IActionResult CommonAccess()
    {
        return Ok("Any authenticated user can access this.");
    }
    
    // Any one can access this endpoint
    [HttpGet("open")]
    public IActionResult OpenAccess()
    {
        return Ok("Any one can access this.");
    }
}