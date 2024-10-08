using System;
using apekade.Models.Dto;
using apekade.Models.Dto.CategoryDto;

namespace apekade.Services;

public interface ICategoryService
{
  Task<ApiRes> CreateCategory(CreateCategoryReqDto createCategoryReqDto);
  Task<ApiRes> AddSubCategories(AddSubCategoriesReqDto addSubCategoriesReqDto);
}