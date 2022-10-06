using MediatR;
using ServicesAPI.Application.Profiles;
using ServicesAPI.Data;
using ServicesAPI.Models;
using ServicesAPI.Queries;

namespace ServicesAPI.Application.Handlers
{
    public class GetAllServiceListHandler : IRequestHandler<GetAllServiceListQuery, List<ServiceDTO>>
    {
        private readonly IServiceRepository _repository;

        public GetAllServiceListHandler(IServiceRepository repository)
        {
            this._repository = repository;
        }
        public Task<List<ServiceDTO>> Handle(GetAllServiceListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetAllServices());
            
        }
    }
}
