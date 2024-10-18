using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using apekade.Models.Enums;

namespace apekade.Models;

public class Notification
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public required string Id { get; set; }
  public required string Title { get; set; }
  public required string Message { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  [BsonRepresentation(BsonType.String)]
  public required NotificationType NotificationType { get; set; }
  public bool IsRead { get; set; } = false;
  [BsonRepresentation(BsonType.ObjectId)]
  public required string VendorId { get; set; }
}