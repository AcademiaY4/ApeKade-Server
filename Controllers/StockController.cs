// ------------------------------------------------------------
// File: StockController.cs
// Description: This file contains the implementation of the 
//              StockController which handles all HTTP requests 
//              related to stock management, including creating, 
//              updating, deleting, and retrieving stock information.
// Author: Perera K.A.S.N.
// ------------------------------------------------------------

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

  // Constructor to initialize the StockService
  public StockController(IStockService stockService)
  {
    _stockService = stockService;
  }

  // Method to test stock category endpoint
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

  // Method to create a new stock entry in the database
  [HttpPost("create-stock")]
  public async Task<IActionResult> CreateStock([FromBody] CreateStockReqDto createStockReqDto)
  {
    var response = await _stockService.CreateStock(createStockReqDto);
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }

  // Method to update an existing stock entry in the database
  [HttpPut("update-stock/{stockId}")]
  public async Task<IActionResult> UpdateStock(string stockId, [FromBody] UpdateStockReqDto updateStockReqDto)
  {
    var response = await _stockService.UpdateStock(stockId, updateStockReqDto);
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }

  // Method to get all stock entries from the database
  [HttpGet("get-all-stocks")]
  public async Task<IActionResult> GetAllStocks()
  {
    var response = await _stockService.GetAllStocks();
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }

  // Method to get a stock entry by its ID from the database
  [HttpGet("get-stock/{stockId}")]
  public async Task<IActionResult> GetStockById(string stockId)
  {
    var response = await _stockService.GetStockById(stockId);
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }

  // Method to delete a stock entry by its ID from the database
  [HttpDelete("delete-stock/{stockId}")]
  public async Task<IActionResult> DeleteStock(string stockId)
  {
    var response = await _stockService.DeleteStock(stockId);
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }
}

