#nullable disable
using System;

namespace apekade.Models.Dto.StockDto;

public class CreateStockResDto
{
  public string Id { get; set; }
  public string ProductId { get; set; }
  public string SubCategory { get; set; }
  public string Category { get; set; }
  public int Quantity { get; set; }
  public bool LowStockAlert { get; set; }
  public DateTime LastUpdated { get; set; }
}