using apekade.Models.Dto.UserDto;
using FluentValidation;
namespace apekade.Models.Validation;

public class ChangePwdWoChkValidator : AbstractValidator<ChangePwdWoChkDto>
{
    public ChangePwdWoChkValidator()
    {
        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("New password is required.")
            .MinimumLength(8).WithMessage("New password must be at least 8 characters long.");
    }
}
