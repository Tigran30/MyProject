using AutoMapper;
using MediatR;
using SuperHeroAPI.Commands;
using SuperHeroAPI.Models;
using SuperHeroAPI.Queries;

namespace SuperHeroAPI.Handlers
{
    public class DeleteSuperHeroHandler : IRequestHandler<DeleteSuperHeroCommand, SuperHero>
    {
        private readonly IMediator _mediator;
        private readonly ISuperHeroRepository _repository;
        private readonly IMapper _mapper;

        public DeleteSuperHeroHandler(IMediator mediator, ISuperHeroRepository repository,IMapper mapper)
        {
            this._mediator = mediator;
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<SuperHero> Handle(DeleteSuperHeroCommand request, CancellationToken cancellationToken)
        {
            //  SuperHero hero = await _mediator.Send(new GetSuperHerobyIdQuery(request.Id));
           
            SuperHero hero = _repository.GetAllSuperHeroes().Find(x=>x.Id==request.Id);
            _repository.DeleteSuperHero(request.Id);
            _repository.SaveChanges();
            return await Task.FromResult(hero);
        }

        private Exception IndexOutOfRangeException()
        {
            throw new NotImplementedException();
        }
    }
}
