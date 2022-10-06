using FluentValidation;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Application.Validations
{
    public class SuperHeroManager : ISuperHeroManager
    {
        private readonly IValidator<SuperHero> validator;

        public SuperHeroManager(IValidator<SuperHero> validator)
        {
            this.validator = validator;
        }
        public async Task Manage(SuperHero hero)
        {
            await validator.ValidateAndThrowAsync(hero);
        }
    }
}
