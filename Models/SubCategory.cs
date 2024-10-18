using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apekade.Models;

public class SubCategory
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string Id { get; set; }
  public required string SubCategoryName { get; set; }
  public required string Status { get; set; }
  public int NoOfProducts { get; set; } = 0;
}