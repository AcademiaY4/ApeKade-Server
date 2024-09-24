using Microsoft.AspNetCore.Mvc;
using apekade.Models.Dto;
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
        return this.ApiRes(200, true, "Server Online", new { Msg = "Server Online" });

    }
    // Only SuperAdmin can access this endpoint
    [Authorize(Roles = "SUPER_ADMIN")]
    [HttpGet("superadmin")]
    public IActionResult SuperAdminOnly()
    {
        return this.ApiRes(200, true, "Only SuperAdmin can access this.", new {});
    }

    // Only Seller can access this endpoint
    [Authorize(Roles = "SELLER")]
    [HttpGet("seller")]
    public IActionResult SellerOnly()
    {
        return this.ApiRes(200, true, "Only Sellers can access this.", new {});
    }

    // Only Buyer can access this endpoint
    [Authorize(Roles = "BUYER")]
    [HttpGet("buyer")]
    public IActionResult BuyerOnly()
    {
        return this.ApiRes(200, true, "Only Buyers can access this.", new {});
    }

    // Both Seller and Buyer can access this endpoint
    [Authorize(Roles = "SELLER,BUYER")]
    [HttpGet("seller-buyer")]
    public IActionResult SellerAndBuyerAccess()
    {
        return this.ApiRes(200, true, "Both Sellers and Buyers can access this.", new {});
    }

    // Any authenticated user can access this endpoint
    [Authorize]
    [HttpGet("common")]
    public IActionResult CommonAccess()
    {
        return this.ApiRes(200, true, "Any authenticated user can access this.", new {});
    }

    // Any one can access this endpoint
    [HttpGet("open")]
    public IActionResult OpenAccess()
    {
        return this.ApiRes(200, true, "Anyone can access this.", new {});
    }
}