using System;

namespace apekade.Models.Dto.ProductDto;

public class UpdateProductReqDto
{
  public string Name { get; set; }
  public decimal Price { get; set; }
  public decimal Discount { get; set; }
  public string Description { get; set; }
  public int Quantity { get; set; }
  public string ImageUrl { get; set; }
  public List<Color>? Colors { get; set; }
  public List<Size>? Sizes { get; set; }
  public string Category { get; set; }
  public string SubCategory { get; set; }
  public string? Brand { get; set; }
  public string VendorID { get; set; }
}

public class UpdateColorReqDto
{
  public string ColorCode { get; set; }
  public int Quantity { get; set; }
}

public class UpdateSizeReqDto
{
  public string SizeString { get; set; }
  public int Quantity { get; set; }
}