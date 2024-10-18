#nullable disable
using System;

namespace apekade.Models.Dto.StockDto;

public class UpdateStockReqDto
{
  public string SubCategory { get; set; }
  public string Category { get; set; }
}