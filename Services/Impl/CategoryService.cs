// ------------------------------------------------------------
// File: CategoryService.cs
// Description: This file contains the implementation of the 
//              CategoryService which handles all business logic 
//              related to categories, including creating, editing, 
//              deleting, and retrieving categories from the database.
// Author: Perera K.A.S.N.
// ------------------------------------------------------------
using apekade.Models;
using apekade.Models.Dto;
using apekade.Models.Dto.CategoryDto;
using apekade.Services;
using AutoMapper;
using MongoDB.Driver;

namespace apekade.Services.Impl;

public class CategoryService : ICategoryService
{
  private readonly IMapper _mapper;
  private readonly IMongoCollection<Category> _categories;

  // Constructor to initialize the service with database collection and mapper
  public CategoryService(IMapper mapper, IMongoDatabase database)
  {
    _mapper = mapper;
    _categories = database.GetCollection<Category>("Categories");
  }

  // Method to add subcategories to an existing category
  public Task<ApiRes> AddSubCategories(AddSubCategoriesReqDto addSubCategoriesReqDto)
  {
    throw new NotImplementedException();
  }

  // Method to create a new category in the database
  public async Task<ApiRes> CreateCategory(CreateCategoryReqDto createCategoryReqDto)
  {
    try
    {
      var newCategory = _mapper.Map<Category>(createCategoryReqDto);
      await _categories.InsertOneAsync(newCategory);
      return new ApiRes(201, true, "Category created successfully", new { });
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }

  // Method to edit an existing category in the database
  public async Task<ApiRes> EditCategory(UpdateCategoryReqDto updateCategoryReqDto)
  {
    try
    {
      var filter = Builders<Category>.Filter.Eq(c => c.Id, updateCategoryReqDto.Id);
      var update = _mapper.Map<Category>(updateCategoryReqDto);
      var result = await _categories.ReplaceOneAsync(filter, update);

      if (result.ModifiedCount > 0)
        return new ApiRes(200, true, "Category updated successfully", new { });
      return new ApiRes(404, false, "Category not found", new { });
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }

  // Method to get all categories from the database
  public async Task<ApiRes> GetAllCategories()
  {
    try
    {
      var categories = await _categories.Find(_ => true).ToListAsync();
      return new ApiRes(200, true, "Categories retrieved successfully", categories);
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }

  // Method to get a category by its ID from the database
  public async Task<ApiRes> GetCategoryById(string categoryId)
  {
    try
    {
      var category = await _categories.Find(c => c.Id == categoryId).FirstOrDefaultAsync();
      if (category != null)
        return new ApiRes(200, true, "Category retrieved successfully", category);
      return new ApiRes(404, false, "Category not found", new { });
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }

  // Method to delete a category by its ID from the database
  public async Task<ApiRes> DeleteCategory(string categoryId)
  {
    try
    {
      var result = await _categories.DeleteOneAsync(c => c.Id == categoryId);
      if (result.DeletedCount > 0)
        return new ApiRes(200, true, "Category deleted successfully", new { });
      return new ApiRes(404, false, "Category not found", new { });
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }

  // Method to activate a category by setting its status to active
  public async Task<ApiRes> ActivateCategory(string categoryId)
  {
    return new ApiRes(500, false, "", new { });
  }

  // Method to deactivate a category by setting its status to inactive
  public async Task<ApiRes> DeactivateCategory(string categoryId)
  {
    return new ApiRes(500, false, "", new { });
  }
}