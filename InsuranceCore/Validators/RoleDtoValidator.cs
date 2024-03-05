using FluentValidation;
using InsuranceCore.Models.Constants;
using InsuranceCore.Models.DTOs.Role;

namespace InsuranceCore.Validators
{
    public class RoleDtoValidator : AbstractValidator<IRoleDto>
    {
        public RoleDtoValidator()
        {
            RuleFor(p => p).NotNull().WithMessage(p => UserMessage.CannotBeNull(nameof(p)));
            RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage(p => UserMessage.CannotBeNullOrEmpty(nameof(p.Name)));
            RuleFor(p => p.Name).Length(1, 20).WithMessage(p => UserMessage.CannotExceed(nameof(p.Name), 20));
        }
    }
}
