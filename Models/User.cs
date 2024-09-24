using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using apekade.Enums;

namespace apekade.Models;

public class User{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string Id { get; set; }
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    [BsonRepresentation((BsonType.String))]
    public required Role Role { get; set; }
}
