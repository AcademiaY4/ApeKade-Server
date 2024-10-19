#nullable disable
using System;

namespace apekade.Models.Dto.VendorDto;

public class GetVendorResDto
{
    public string Id { get; set; }
    public string ShopName { get; set; }
    public string ShopDescription { get; set; }

    // Vendor-specific data
    public List<Rating> VendorRatings { get; set; }
}
