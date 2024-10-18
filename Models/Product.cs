using apekade.Models.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apekade.Models;

public class Product
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string Id { get; set; }
  public required string Name { get; set; }
  public required decimal Price { get; set; }
  public decimal? Discount { get; set; }
  public string? Description { get; set; }
  public required int Quantity { get; set; }
  public string? ImageUrl { get; set; }
  public List<String>? Colors { get; set; }
  public List<String>? Sizes { get; set; }
  public required string Category { get; set; }
  public required string SubCategory { get; set; }
  public string? Brand { get; set; }
  public bool IsActive { get; set; } = true; 
  [BsonRepresentation(BsonType.ObjectId)]
  public required string VendorID { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}