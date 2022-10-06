using MediatR;
using SuperHeroAPI.Models;
using SuperHeroAPI.Queries;

namespace SuperHeroAPI.Handlers
{
    public class GetSuperHerobyIdHandler: IRequestHandler<GetSuperHerobyIdQuery, SuperHero>
    {
        private readonly IMediator _mediatr;

        public GetSuperHerobyIdHandler(IMediator mediator)
        {
            this._mediatr = mediator;
        }

        public async Task<SuperHero> Handle(GetSuperHerobyIdQuery request, CancellationToken cancellationToken)
        {
            var results = await _mediatr.Send(new GetSuperHeroListQuery());
            var output = results.FirstOrDefault(x => x.Id == request.Id);
            return output;
        }
    }
}
