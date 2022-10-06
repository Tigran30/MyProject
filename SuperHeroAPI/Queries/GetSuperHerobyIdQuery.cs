using MediatR;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Queries
{
    public record GetSuperHerobyIdQuery(int Id) :IRequest<SuperHero>;
    
}
