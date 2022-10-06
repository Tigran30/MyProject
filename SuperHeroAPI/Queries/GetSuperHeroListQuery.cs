using MediatR;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Queries
{
    public record GetSuperHeroListQuery(): IRequest<List<SuperHero>>;
    

    
}
