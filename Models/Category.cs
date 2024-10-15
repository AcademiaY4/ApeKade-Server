using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apekade.Models;

public class Category
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string Id { get; set; }
  public required string CategoryName { get; set; }
  public int NoOfProducts { get; set; } = 0;
  public required string Status { get; set; }
  public List<SubCategory>? SubCategories { get; set; } = [];
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}