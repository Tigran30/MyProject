using SuperHeroAPI.Models;

namespace SuperHeroAPI.Application.Validations
{
    public interface ISuperHeroManager
    {
        Task Manage(SuperHero hero);
    }
}