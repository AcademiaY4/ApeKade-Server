// ------------------------------------------------------------
// File: CategoryController.cs
// Description: This file contains the controller implementation 
//              for managing category-related operations such as 
//              creation, update, fetching, and status management.
// Author: Perera K.A.S.N.
// ------------------------------------------------------------

using apekade.Models.Dto;
using apekade.Models.Dto.CategoryDto;
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

  // Method to create a new category
  [HttpPost("create")]
  public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryReqDto createCategoryReqDto)
  {
    var response = await _categoryService.CreateCategory(createCategoryReqDto);
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }

  // Method to edit an existing category
  [HttpPut("edit")]
  public async Task<IActionResult> EditCategory([FromBody] UpdateCategoryReqDto updateCategoryReqDto)
  {
    var response = await _categoryService.EditCategory(updateCategoryReqDto);
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }

  // Method to fetch all categories
  [HttpGet("get")]
  public async Task<IActionResult> GetCategories()
  {
    var response = await _categoryService.GetAllCategories();
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }

  // Method to fetch a category by its ID
  [HttpGet("get/{id}")]
  public async Task<IActionResult> GetCategoryById(string id)
  {
    var response = await _categoryService.GetCategoryById(id);
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }

  // Method to delete a category
  [HttpDelete("delete/{id}")]
  public async Task<IActionResult> DeleteCategory(string id)
  {
    var response = await _categoryService.DeleteCategory(id);
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }

  // Method to activate a category (update status to active)
  [HttpPatch("activate/{id}")]
  public async Task<IActionResult> ActivateCategory(string id)
  {
    var response = await _categoryService.ActivateCategory(id);
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }

  // Method to deactivate a category (update status to inactive)
  [HttpPatch("deactivate/{id}")]
  public async Task<IActionResult> DeactivateCategory(string id)
  {
    var response = await _categoryService.DeactivateCategory(id);
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }
}

