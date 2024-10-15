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
using MongoDB.Bson;

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
    Console.WriteLine(createCategoryReqDto.ToString());
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }

  // Method to edit an existing category
  [HttpPut("edit/{id}")]
  public async Task<IActionResult> EditCategory(string id, [FromBody] UpdateCategoryReqDto updateCategoryReqDto)
  {
    if (!ObjectId.TryParse(id, out var objectId))
      return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);
    

    var response = await _categoryService.EditCategory(id, updateCategoryReqDto);
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

  [HttpPut("update-noofproducts")]
  public async Task<IActionResult> UpdateNoOfProducts([FromBody] UpdateNoOfProductsReqDto updateNoOfProductsReqDto)
  {
    if (!ObjectId.TryParse(updateNoOfProductsReqDto.CategoryId, out var categoryId) ||
        !ObjectId.TryParse(updateNoOfProductsReqDto.SubCategoryId, out var subCategoryId))
    {
      return this.ApiRes(400, false, "Invalid MongoDB ObjectId.", null);
    }

    var response = await _categoryService.UpdateNoOfProducts(updateNoOfProductsReqDto);
    return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
  }

}

