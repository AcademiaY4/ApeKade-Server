#nullable disable
using System;

namespace apekade.Models.Dto.CategoryDto;

public class CreateCategoryReqDto
{
  public string CategoryName { get; set; }
  public string Status { get; set; }
  public List<CreateSubCategoryReqDto> SubCategories { get; set; }
}

public class CreateSubCategoryReqDto
{
  public required string SubCategoryName { get; set; } 
  public required string Status { get; set; } 
}