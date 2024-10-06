using System;
using apekade.Models.Enums;
using apekade.Models.Dto.UserDto;
using FluentValidation;

namespace apekade.Models.Validation.UserValidation;

public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.");

        RuleFor(x => x.Role)
            .NotEmpty()
            .WithMessage("Role should not be empty.")
            .Must(IsValidRole)
            .WithMessage("Role is not valid.");

        RuleFor(x => x.Telephone)
            .NotEmpty()
            .WithMessage("Telephone is required.")
            .Matches(@"^\d{9}$")
            .WithMessage("Telephone must be exactly 9 digits.");

        RuleFor(x => x.Age)
            .NotEmpty()
            .WithMessage("Age is required.")
            .InclusiveBetween(14, 100)
            .WithMessage("Age must be between 14 and 100.");

        RuleFor(x => x.Province)
            .NotEmpty()
            .WithMessage("Province is required.")
            .Must(IsValidProvince)
            .WithMessage("Province is not valid.");

        RuleFor(x => x.District)
            .NotEmpty()
            .WithMessage("District is required.")
            .Must(IsValidDistrict)
            .WithMessage("District is not valid.");

        RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage("City is required.");

        RuleFor(x => x.ZipCode)
            .NotEmpty()
            .WithMessage("ZipCode is required.");

        RuleFor(x => x.Company)
            .MaximumLength(100) // Limit length to a reasonable size
            .WithMessage("Company name cannot exceed 100 characters.")
            .When(x => !string.IsNullOrEmpty(x.Company));
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
