#nullable disable
using System;

namespace apekade.Models.Dto.CategoryDto;

public class CreateCategoryReqDto
{
  public string CategoryName { get; set; }
  public string Status { get; set; }
}