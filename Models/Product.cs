using apekade.Models.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apekade.Models;

public class Product
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public required string Id { get; set; }
  public required string Name { get; set; }
  public required decimal Price { get; set; }
  public decimal? Discount { get; set; }
  public string? Description { get; set; }
  public required int Quantity { get; set; }
  public List<String>? ImageUrls { get; set; }
  [BsonRepresentation(BsonType.String)]
  public required ProductCategory Category { get; set; }
  public string? Brand { get; set; }
  public bool IsFeatured { get; set; } = false;
  public bool IsActive { get; set; } = true;
  public string CreatedBy { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}