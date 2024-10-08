using apekade.Models.Dto;
using apekade.Models.Dto.CategoryDto;
using apekade.Models.Dto.StockDto;
using apekade.Services;
using Microsoft.AspNetCore.Mvc;

namespace apekade.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
  private readonly ICategoryService _categoryService;
  public CategoryController(ICategoryService categoryService)
  {
    _categoryService = categoryService;
  }

  [HttpPost("create")]
  public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryReqDto createCategoryReqDto)
  {
    var response = await _categoryService.CreateCategory(createCategoryReqDto);
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }
}