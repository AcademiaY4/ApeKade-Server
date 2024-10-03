using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using apekade.Enums;
using apekade.Models.Enums;

namespace apekade.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string Id { get; set; }
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    [BsonRepresentation((BsonType.String))]
    public required Role Role { get; set; }
    // For customer account approval by CSR/Admin
    public required bool IsApproved { get; set; } = false;
    // Can be 'PENDING', 'ACTIVE', or 'DEACTIVATED'
    [BsonRepresentation((BsonType.String))]
    public required Status Status { get; set; } = Status.PENDING;
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    // Applicable for vendors only
    public List<Rating>? VendorRatings { get; set; }
}
