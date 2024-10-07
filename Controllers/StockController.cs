using apekade.Models.Dto;
using apekade.Models.Dto.StockDto;
using apekade.Services;
using Microsoft.AspNetCore.Mvc;

namespace apekade.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
  private readonly IStockService _stockService;
  public StockController(IStockService stockService)
  {
    _stockService = stockService;
  }

  [HttpGet("test-stock")]
  public IActionResult TestStockCategory()
  {
    object result = new
    {
      stockName = "Rubic Cube",
      stockCategory = "Toys",
      stockQuantity = 1000,
      stockPrice = 10.00,
      stockDescription = "This is a rubic cube for sale."
    };
    return this.ApiRes(200, true, "This is test stock", result);
  }

  [HttpPost("create-stock")]
  public async Task<IActionResult> CreateStock([FromBody] CreateStockReqDto createStockReqDto)
  {
    var response = await _stockService.CreateStock(createStockReqDto);
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }
}

