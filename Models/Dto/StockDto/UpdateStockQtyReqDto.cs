#nullable disable
using System;

namespace apekade.Models.Dto.StockDto;

public class UpdateStockQtyReqDto
{
  public string Id { get; set; }

  public int Quantity { get; set; }
  public bool LowStockAlert { get; set; }
}