#nullable disable
using System;

namespace apekade.Models.Dto.VendorDto;

public class AddVendorRatingDto
{
    public string VendorId { get; set; }
    public float ItemQualityRating { get; set; }
    public float CommunicationRating { get; set; }
    public float ShippingSpeedRating { get; set; }  
    public string Comment { get; set; }
    public string CustomerId { get; set; }
}
