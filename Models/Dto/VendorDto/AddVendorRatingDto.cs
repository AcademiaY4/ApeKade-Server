#nullable disable
using System;

namespace apekade.Models.Dto.VendorDto;

public class AddVendorRatingDto
{
    public string VendorId { get; set; }
    public int Stars { get; set; }
    public string Comment { get; set; }
    public string CustomerId { get; set; }
}
