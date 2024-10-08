// ------------------------------------------------------------
// File: ICategoryService.cs
// Description: This interface defines the contract for category-related 
//              operations including creating, editing, retrieving, 
//              deleting, and activating/deactivating categories.
// Author: Perera K.A.S.N.
// ------------------------------------------------------------

using System;
using apekade.Models.Dto;
using apekade.Models.Dto.CategoryDto;

namespace apekade.Services;

public interface ICategoryService
{
  // Method to create a new category
  Task<ApiRes> CreateCategory(CreateCategoryReqDto createCategoryReqDto);

  // Method to add subcategories to a category
  Task<ApiRes> AddSubCategories(AddSubCategoriesReqDto addSubCategoriesReqDto);

  // Method to update an existing category
  Task<ApiRes> EditCategory(UpdateCategoryReqDto updateCategoryReqDto);

  // Method to retrieve all categories
  Task<ApiRes> GetAllCategories();

  // Method to retrieve a category by its ID
  Task<ApiRes> GetCategoryById(string categoryId);

  // Method to delete a category by its ID
  Task<ApiRes> DeleteCategory(string categoryId);

  // Method to activate a category by its ID (set its status to active)
  Task<ApiRes> ActivateCategory(string categoryId);

  // Method to deactivate a category by its ID (set its status to inactive)
  Task<ApiRes> DeactivateCategory(string categoryId);
}

