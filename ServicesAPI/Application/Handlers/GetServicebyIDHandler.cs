using MediatR;
using ServicesAPI.Application.Profiles;
using ServicesAPI.Data;
using ServicesAPI.Queries;

namespace ServicesAPI.Application.Handlers
{
    public class GetServicebyIDHandler : IRequestHandler<GetServicebyIDQuery, ServiceDTO>
    {
       private readonly IServiceRepository _repository;

        public GetServicebyIDHandler(IServiceRepository repository)
        {
            this._repository = repository;
        }

        public Task<ServiceDTO> Handle(GetServicebyIDQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetServicebyId(request.ID));
        }
    }
}
