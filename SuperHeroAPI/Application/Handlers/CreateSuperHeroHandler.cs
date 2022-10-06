using MediatR;
using SuperHeroAPI.Commands;
using SuperHeroAPI.Models;
using SuperHeroAPI.Application;
using SuperHeroAPI.Application.Commands.mapper;
using AutoMapper;

namespace SuperHeroAPI.Handlers
{
    public class CreateSuperHeroHandler : IRequestHandler<CreateSuperHeroCommand, bool>
    {
        private readonly ISuperHeroRepository _repository;
        private readonly IMapper _mapper;

        public CreateSuperHeroHandler(ISuperHeroRepository repository,IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<bool> Handle(CreateSuperHeroCommand request, CancellationToken cancellationToken)
        {
            //SuperHero hero = new SuperHero();


            //SuperHero hero = new SuperHero { Name = request.Name, FirstName = request.FirstName, LastName = request.LastName, Place = request.Place };
            var superheroDto=_mapper.Map<SuperHero>(request);
            await _repository.CreateSuperHero(superheroDto);
            return true;
        }
    }
}
