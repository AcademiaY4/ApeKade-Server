#nullable disable
using System;

namespace apekade.Models.Dto.BuyerDto;

public class GetReviewResDto
{
    public float ItemQualityRating { get; set; }
    public float CommunicationRating { get; set; }
    public float ShippingSpeedRating { get; set; }
    public string Comment { get; set; }
    public string VendorId { get; set; }
    public DateTime Added { get; set; }
}