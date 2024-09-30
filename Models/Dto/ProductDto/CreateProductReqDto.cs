using System;

namespace apekade.Models.Dto.ProductDto;

public class CreateProductReqDto
{
  public string Name { get; set; }
  public decimal Price { get; set; }
  public string Description { get; set; }
  public int Quantity { get; set; }
  public string ImageUrl { get; set; }
  public string Category { get; set; }
  public string? Brand { get; set; }
  public bool IsFeatured { get; set; } = false;
  public bool IsActive { get; set; } = true;
  public string CreatedBy { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}