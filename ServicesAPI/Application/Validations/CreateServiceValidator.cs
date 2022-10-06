using FluentValidation;
using ServicesAPI.Application.Commands;

namespace ServicesAPI.Application.Validations
{
    public class CreateServiceValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceValidator()
        {
            RuleFor(x => x.ServiceName).MinimumLength(3).MaximumLength(20).NotNull();
            RuleFor(x => x.ServiceCost >= 0).NotNull();
        }
    }
}
