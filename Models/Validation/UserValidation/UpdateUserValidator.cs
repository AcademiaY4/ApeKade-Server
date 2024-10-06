using System;
using apekade.Enums;
using apekade.Models.Dto.UserDto;
using FluentValidation;

namespace apekade.Models.Validation.UserValidation;

public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserValidator()
    {
        // RuleFor(x => x.Id)
        //     .NotEmpty()
        //     .WithMessage("user Id is required.");

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.");
        
        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.");

        // RuleFor(x => x.Email)
        //     .NotEmpty()
        //     .EmailAddress()
        //     .WithMessage("A valid email is required.");

        RuleFor(x => x.Role)
            .NotEmpty()
            .WithMessage("role should not be empty")
            .Must(IsValidRole)
            .WithMessage("role not valid .");
    }
    private bool IsValidRole(string role)
    {
        return Enum.TryParse(typeof(Role), role, true, out _);
    }
}
