#nullable disable
using System;

namespace apekade.Models.Dto.CategoryDto;

public class AddSubCategoriesReqDto
{
  public string SubCategoryName { get; set; }
  public int NoOfProducts { get; set; }
}