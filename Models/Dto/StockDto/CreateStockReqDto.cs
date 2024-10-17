#nullable disable
using System;

namespace apekade.Models.Dto.StockDto;

public class CreateStockReqDto
{
  public string ProductId { get; set; }
  public string SubCategory { get; set; }
  public string Category { get; set; }
  public int Quantity { get; set; }
}