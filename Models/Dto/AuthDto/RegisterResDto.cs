#nullable disable
namespace apekade.Models.Dto.AuthDto;

public class RegisterResDto
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Telephone { get; set; }
    public int Age { get; set; }
    public string Status { get; set; }
    public string IsApproved { get; set; }
    public string Province { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Company { get; set; }
    public DateTime DateCreated { get; set; }

    // Vendor-specific data
    public List<Rating> VendorRatings { get; set; }
}
