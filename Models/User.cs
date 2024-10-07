using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using apekade.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace apekade.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string Id { get; set; }
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
    // Telephone validation: Must match a pattern for phone numbers (e.g., Sri Lankan format)
    [RegularExpression(@"^\d{9}$", ErrorMessage = "Telephone must be exactly 9 digits.")]
    public string Telephone { get; set; } = string.Empty;
    // Age validation: Should be between 14 and 100
    [Range(14, 100, ErrorMessage = "Age must be between 14 and 100")]
    public int? Age { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    [BsonRepresentation((BsonType.String))]
    public required Role Role { get; set; }
    // For customer account approval by CSR/Admin
    public required bool IsApproved { get; set; } = false;
    // Can be 'PENDING', 'ACTIVE', or 'DEACTIVATED'
    [BsonRepresentation((BsonType.String))]
    public required Status Status { get; set; } = Status.PENDING;

    // Address Fields
    [BsonRepresentation(BsonType.String)]
    public required Province Province { get; set; }
    [BsonRepresentation(BsonType.String)]
    public required District District { get; set; }
    public required string City { get; set; }
    public string? ZipCode { get; set; }
    public string? Company { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    // Applicable for vendors only
    public List<Rating>? VendorRatings { get; set; } = null;
}
