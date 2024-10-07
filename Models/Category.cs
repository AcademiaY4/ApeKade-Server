using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apekade.Models;

public class Category
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public required string Id { get; set; }
  public required string CategoryName { get; set; }
  public required string NoOfProducts { get; set; }
  public required string Status { get; set; } = "Published";
  public List<SubCategory>? SubCategory { get; set; } = null;
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}