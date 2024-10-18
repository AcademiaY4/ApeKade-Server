#nullable disable
using System;

namespace apekade.Models.Dto.CategoryDto;

public class CreateCategoryResDto
{
  public string Id { get; set; }
  public string CategoryName { get; set; }
  public int NoOfProducts { get; set; }
  public string Status { get; set; }
  public List<SubCategory> SubCategories { get; set; }
  public DateTime CreatedAt { get; set; }
}