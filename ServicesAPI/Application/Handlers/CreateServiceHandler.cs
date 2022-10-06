using AutoMapper;
using MediatR;
using ServicesAPI.Application.Commands;
using ServicesAPI.Application.Profiles;
using ServicesAPI.Data;
using ServicesAPI.Models;

namespace ServicesAPI.Application.Handlers
{
    public class CreateServiceHandler : IRequestHandler<CreateServiceCommand, ServiceDTO>
    {
        private readonly IServiceRepository _repository;
        private readonly IMapper _mapper;

        

        public CreateServiceHandler(IServiceRepository repository,IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }

        public Task<ServiceDTO> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult( _repository.CreateService(_mapper.Map<Service>(request)));
        }
    }
}
