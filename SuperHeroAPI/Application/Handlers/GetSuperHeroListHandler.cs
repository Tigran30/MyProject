using MediatR;
using SuperHeroAPI.Models;
using SuperHeroAPI.Queries;

namespace SuperHeroAPI.Handlers
{
    public class GetSuperHeroListHandler : IRequestHandler<GetSuperHeroListQuery, List<SuperHero>>
    {
        private readonly ISuperHeroRepository _repository;

        public GetSuperHeroListHandler(ISuperHeroRepository repository)
        {
            this._repository = repository;
        }
        public Task<List<SuperHero>> Handle(GetSuperHeroListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetAllSuperHeroes());
        }
    }
}
