using FluentValidation;
using InsuranceCore.Models.Constants;
using InsuranceCore.Models.DTOs.Tag;

namespace InsuranceCore.Validators
{
    public class TagDtoValidator : AbstractValidator<ITagDto>
    {
        public TagDtoValidator()
        {
            RuleFor(p => p).NotNull().WithMessage(p => UserMessage.CannotBeNull(nameof(p)));
            RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage(p => UserMessage.CannotBeNullOrEmpty(nameof(p.Name)));
            RuleFor(p => p.Name).Length(1, 50).WithMessage(p => UserMessage.CannotExceed(nameof(p.Name), 50));
        }
    }
}
