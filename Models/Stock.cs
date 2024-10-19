using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using apekade.Models.Enums;

namespace apekade.Models;

public class Stock
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public required string Id { get; set; }
  [BsonRepresentation(BsonType.ObjectId)]
  public required string ProductId { get; set; }
  [BsonRepresentation(BsonType.String)]
  public required SubCategory SubCategory { get; set; }
  [BsonRepresentation(BsonType.String)]
  public required Category  Category{ get; set; }
  public required int Quantity { get; set; }
  public bool LowStockAlert { get; set; } = false;
  public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
}