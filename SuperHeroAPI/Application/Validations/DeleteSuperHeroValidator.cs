using FluentValidation;
using MediatR;
using SuperHeroAPI.Commands;
namespace SuperHeroAPI.Validations
{
    public class DeleteSuperHeroValidator : AbstractValidator<DeleteSuperHeroCommand>
    {
        public DeleteSuperHeroValidator()
        {
            RuleFor(x=>x.Id).GreaterThanOrEqualTo(0);
        }
    }
}
