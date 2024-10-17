#nullable disable
using System;

namespace apekade.Models.Dto.CategoryDto;

public class UpdateCategoryReqDto
{
  public string Id { get; set; }
  public string CategoryName { get; set; }
  public string Status { get; set; }
}