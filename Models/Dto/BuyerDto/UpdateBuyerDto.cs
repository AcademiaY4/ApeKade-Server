#nullable disable
using System;

namespace apekade.Models.Dto.BuyerDto;

public class UpdateBuyerDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Telephone { get; set; }
    public int Age { get; set; }
    public string District { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
}

