using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apekade.Models;

public class Color
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string Id { get; set; }
  public required string ColorCode { get; set; }
  public required int Quantity { get; set; }
}