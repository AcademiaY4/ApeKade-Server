using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apekade.Models;

public class Size
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string Id { get; set; }
  public required string SizeString { get; set; }
  public required int Quantity { get; set; }
}