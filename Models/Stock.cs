using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apekade.Models;

public class Stock
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public required string Id { get; set; }
  [BsonRepresentation(BsonType.ObjectId)]
  public required string ProductId { get; set; }
  public required string SubCategory { get; set; }
  public required string Category { get; set; }
  public required int Quantity { get; set; }
  public bool LowStockAlert { get; set; } = false;
  public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
}