using FluentValidation;
using ServicesAPI.Application.Commands;

namespace ServicesAPI.Application.Validations
{
    public class UpDateServiceValidator : AbstractValidator<UpDateServiceCommand>
    {
        public UpDateServiceValidator()
        {
            RuleFor(x => x.ServiceName).MinimumLength(3).MaximumLength(20).NotNull();
            RuleFor(x => x.ServiceCost >= 0).NotNull();
        }
    }
}
