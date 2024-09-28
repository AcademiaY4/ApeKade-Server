using System;
using apekade.Models.Dto.BuyerDto;
using FluentValidation;

namespace apekade.Models.Validation.BuyerValidation;

public class UpdateBuyerValidator : AbstractValidator<UpdateBuyerDto>
{
    public UpdateBuyerValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.");

    }
}
