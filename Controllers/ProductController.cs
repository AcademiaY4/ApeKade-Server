using apekade.Models.Dto;
using apekade.Models.Dto.ProductDto;
using apekade.Models.Dto.StockDto;
using apekade.Services;
using Microsoft.AspNetCore.Mvc;

namespace apekade.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
  private readonly IProductService _productService;

  public ProductController(IProductService productService)
  {
    _productService = productService;
  }

  [HttpPost("create")]
  public async Task<IActionResult> CreateProduct([FromBody] CreateProductReqDto createProductReqDto)
  {
    var response = await _productService.CreateProduct(createProductReqDto);
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }

  [HttpGet("get")]
  public async Task<IActionResult> GetAllProducts()
  {
    var response = await _productService.GetAllProducts();
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }

  [HttpGet("get/{id}")]
  public async Task<IActionResult> GetStockById(string id)
  {
    var response = await _productService.GetProductById(id);
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }
}