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

  public CategoryService(IMapper mapper, IMongoDatabase database)
  {
    _mapper = mapper;
    _categories = database.GetCollection<Category>("Categories");
  }

    public Task<ApiRes> AddSubCategories(AddSubCategoriesReqDto addSubCategoriesReqDto)
    {
        throw new NotImplementedException();
    }

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
}