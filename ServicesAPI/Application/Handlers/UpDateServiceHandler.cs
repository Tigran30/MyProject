using AutoMapper;
using MediatR;
using ServicesAPI.Application.Commands;
using ServicesAPI.Application.Profiles;
using ServicesAPI.Data;
using ServicesAPI.Models;

namespace ServicesAPI.Application.Handlers
{
    public class UpDateServiceHandler : IRequestHandler<UpDateServiceCommand, ServiceDTO>
    {
        private readonly IServiceRepository _repository;
        private readonly IMapper _mapper;

        public UpDateServiceHandler(IServiceRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public Task<ServiceDTO> Handle(UpDateServiceCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.UpDateService(_mapper.Map<Service>(request)));
        }
    }
}
