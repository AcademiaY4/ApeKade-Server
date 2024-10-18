using System;
using apekade.Models.Dto.AuthDto;
using FluentValidation;
using System.Linq;
using apekade.Models.Enums;

namespace apekade.Models.Validation;

public class RegisterValidator : AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("A valid email is required.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters.");

        RuleFor(x => x.Role)
            .NotEmpty()
            .WithMessage("role should not be empty")
            .Must(IsValidRole)
            .WithMessage("role not valid .");

        RuleFor(x => x.Province)
            .NotEmpty()
            .WithMessage("province should not be empty")
            .Must(IsValidProvince)
            .WithMessage("province not valid .");

        RuleFor(x => x.District)
            .NotEmpty()
            .WithMessage("district should not be empty")
            .Must(IsValidDistrict)
            .WithMessage("district not valid .");

        RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage("city not valid .");

        RuleFor(x => x.Age)
            .NotEmpty()
            .WithMessage("age should not be empty")
            .InclusiveBetween(14, 100)
            .WithMessage("Age must be between 14 and 100.");

        RuleFor(x => x.Telephone)
            .NotEmpty()
            .WithMessage("Telephone number is required.")
            .Matches(@"^\+94\d{9}$")
            .WithMessage("Telephone must be in the format +94XXXXXXXXX.");
    }

    private bool IsValidRole(string role)
    {
        return Enum.TryParse(typeof(Role), role, true, out _);
    }
    private bool IsValidProvince(string province)
    {
        return Enum.TryParse(typeof(Province), province, true, out _);
    }

    private bool IsValidDistrict(string district)
    {
        return Enum.TryParse(typeof(District), district, true, out _);
    }
}
