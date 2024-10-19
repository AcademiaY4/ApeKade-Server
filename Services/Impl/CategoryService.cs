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
using MongoDB.Bson;
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
      var newCategory = new Category
      {
        CategoryName = createCategoryReqDto.CategoryName,
        Status = createCategoryReqDto.Status,
        SubCategories = createCategoryReqDto.SubCategories?.Select(sc => new SubCategory
        {
          Id = ObjectId.GenerateNewId().ToString(),
          SubCategoryName = sc.SubCategoryName,
          Status = sc.Status,
          NoOfProducts = 0
        }).ToList() ?? [],
      };

      //var newCategory = _mapper.Map<Category>(createCategoryReqDto);
      await _categories.InsertOneAsync(newCategory);
      return new ApiRes(201, true, "Category created successfully", new { });
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }

  // Method to edit an existing category in the database
  public async Task<ApiRes> EditCategory(string id, UpdateCategoryReqDto updateCategoryReqDto)
  {
    try
    {
      var category = await _categories.Find(category => category.Id == id).FirstOrDefaultAsync();
      if (category == null) return new ApiRes(404, false, "Category not found", new { });

      var updatedSubCategories = new List<SubCategory>();

      foreach (var subCategoryDto in updateCategoryReqDto.SubCategories)
      {
        // Check if subcategory exists in the current category
        var existingSubCategory = category.SubCategories?.FirstOrDefault(sc => sc.SubCategoryName == subCategoryDto.SubCategoryName);

        if (existingSubCategory != null)
        {
          // Update fields but preserve Id and NoOfProducts
          existingSubCategory.SubCategoryName = subCategoryDto.SubCategoryName;
          existingSubCategory.Status = subCategoryDto.Status;

          // Add to the updated list
          updatedSubCategories.Add(existingSubCategory);
        }
        else
        {
          // Add new subcategory with auto-generated Id by MongoDB
          var newSubCategory = new SubCategory
          {
            SubCategoryName = subCategoryDto.SubCategoryName,
            Status = subCategoryDto.Status,
            NoOfProducts = 0 // Initialize NoOfProducts for new subcategory
          };

          updatedSubCategories.Add(newSubCategory);
        }
      }

      // Assign the manually updated SubCategories back to the category
      category.SubCategories = updatedSubCategories;

      // Use AutoMapper to map other fields from the DTO, but exclude the fields we handled manually
      _mapper.Map(updateCategoryReqDto, category);

      // Replace the updated category in the database
      await _categories.ReplaceOneAsync(c => c.Id == category.Id, category);

      var categoryRes = _mapper.Map<GetCategoryResDto>(category);
      return new ApiRes(200, true, "Category updated successfully", new { categoryRes });
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
      var category = await _categories.Find(category => category.Id == categoryId).FirstOrDefaultAsync();
      if (category == null) return new ApiRes(404, false, "Category not found", new { });

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

  public async Task<ApiRes> UpdateNoOfProducts(UpdateNoOfProductsReqDto updateNoOfProductsReqDto)
  {  
    try
    {
      // Find the category by its Id
      var category = await _categories.Find(c => c.Id == updateNoOfProductsReqDto.CategoryId).FirstOrDefaultAsync();
      if (category == null) return new ApiRes(404, false, "Category not found", new { });

      // Update the NoOfProducts of the category
      category.NoOfProducts += updateNoOfProductsReqDto.Amount;

      // Find the subcategory by its Id and update its NoOfProducts
      var subCategory = category.SubCategories?.FirstOrDefault(sc => sc.Id == updateNoOfProductsReqDto.SubCategoryId);
      if (subCategory != null)
      {
        subCategory.NoOfProducts += updateNoOfProductsReqDto.Amount;
      }
      else
      {
        return new ApiRes(404, false, "Subcategory not found", new { });
      }

      // Save the updated category and subcategory
      await _categories.ReplaceOneAsync(c => c.Id == category.Id, category);

      return new ApiRes(200, true, "NoOfProducts updated successfully", new { });
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }

}