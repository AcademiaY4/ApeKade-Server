using System;
using apekade.Models.Dto.VendorDto;
using FluentValidation;

namespace apekade.Models.Validation.VendorValidation;

public class UpdateVendorValidator : AbstractValidator<UpdateVendorDto>
{
    public UpdateVendorValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.");
    }

}
