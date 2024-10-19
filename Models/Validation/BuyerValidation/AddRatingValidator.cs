using System;
using apekade.Models.Dto.VendorDto;
using FluentValidation;

namespace apekade.Models.Validation.BuyerValidation;

public class AddRatingValidator : AbstractValidator<AddVendorRatingDto>
{
    public AddRatingValidator()
    {
        RuleFor(x => x.VendorId)
            .NotEmpty()
            .WithMessage("vendor Id is required.");

        RuleFor(x => x.ItemQualityRating)
            .NotEmpty()
            .WithMessage("stars is required.").InclusiveBetween(1,5).WithMessage("stars must be  within 1 to 5");

        RuleFor(x => x.CommunicationRating)
            .NotEmpty()
            .WithMessage("stars is required.").InclusiveBetween(1,5).WithMessage("stars must be  within 1 to 5");

        RuleFor(x => x.ShippingSpeedRating)
            .NotEmpty()
            .WithMessage("stars is required.").InclusiveBetween(1,5).WithMessage("stars must be  within 1 to 5");

        RuleFor(x => x.Comment)
           .NotEmpty()
           .WithMessage("comment is required.");

    }
}
