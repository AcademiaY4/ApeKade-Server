using System;
using apekade.Enums;
using apekade.Models.Dto.UserDto;
using FluentValidation;

namespace apekade.Models.Validation;

public class CreateUserValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserValidator(){
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
    }
    private bool IsValidRole(string role)
    {
        return Enum.TryParse(typeof(Role), role, true, out _);
    }
}
