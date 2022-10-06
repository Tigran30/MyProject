using AutoMapper;
using MediatR;
using SuperHeroAPI.Commands;
using SuperHeroAPI.Models;
using SuperHeroAPI.Queries;

namespace SuperHeroAPI.Handlers
{
    public class UpdateSuperHeroHandler : IRequestHandler<UpDateSuperHeroCommand, SuperHero>
    {
        private readonly IMediator _mediatr;
        private readonly ISuperHeroRepository _repository;
        private readonly IMapper _mapper;

        public UpdateSuperHeroHandler(IMediator mediator, ISuperHeroRepository repository, IMapper mapper)
        {
            this._mediatr = mediator;
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<SuperHero> Handle(UpDateSuperHeroCommand request, CancellationToken cancellationToken)
        {

            var result = _repository.UpdateSuperHero(_mapper.Map<SuperHero>(request));
            _repository.SaveChanges();
            return await Task.FromResult(result);
        }

        private Exception IndexOutOfRangeException()
        {
            throw new NotImplementedException();
        }
    }
}
