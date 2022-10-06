using FluentValidation;
using MediatR;
using SuperHeroAPI.Commands;
namespace SuperHeroAPI.Validations
{
    public class UpDateSuperHeroValidator : AbstractValidator<UpDateSuperHeroCommand>
    {
        public UpDateSuperHeroValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.FirstName).MinimumLength(3).MaximumLength(15).NotNull();
            RuleFor(x => x.LastName).MaximumLength(15).NotNull();
            RuleFor(x => x.Place).NotNull().NotEmpty();

        }

    }
}
