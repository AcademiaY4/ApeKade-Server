#nullable disable
using System;

namespace apekade.Models.Dto.CategoryDto;

public class UpdateCategoryReqDto
{
  public string CategoryName { get; set; }
  public string Status { get; set; }
  public List<UpdateSubCategoryReqDto> SubCategories { get; set; }
}

public class UpdateSubCategoryReqDto
{
  public required string SubCategoryName { get; set; }
  public required string Status { get; set; }
}