using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apekade.Models;

public class Rating
{
    [Required]
    public required int Stars { get; set; } 
    
    [Required]
    public required int ItemQualityRating { get; set; } 
    
    [Required]
    public required int CommunicationRating { get; set; } 

    [Required]
    public required decimal ShippingSpeedRating { get; set; } 

    [Required]
    public required string Comment { get; set; }  
    [BsonRepresentation(BsonType.ObjectId)]
    public required string CustomerId { get; set; }
    public DateTime Added { get; set; } = DateTime.UtcNow;
}
