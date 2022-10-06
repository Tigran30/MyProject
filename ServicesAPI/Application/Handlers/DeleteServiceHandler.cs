using AutoMapper;
using MediatR;
using ServicesAPI.Application.Commands;
using ServicesAPI.Application.Profiles;
using ServicesAPI.Data;

namespace ServicesAPI.Application.Handlers
{
    public class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand, ServiceDTO>
    {
        private readonly IServiceRepository _repository;
       

        public DeleteServiceHandler(IServiceRepository repository)
        {
            this._repository = repository;
            
        }
        public Task<ServiceDTO> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.DeleteService(request.ID));
        }
    }
}
