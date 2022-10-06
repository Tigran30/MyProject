using MediatR;
using ServicesAPI.Application.Profiles;

namespace ServicesAPI.Application.Commands
{
    public class CreateServiceCommand : IRequest<ServiceDTO>

    {
        public CreateServiceCommand(int id, string serviceName, int serviceCost)
        {
            Id = id;
            ServiceName = serviceName;
            ServiceCost = serviceCost;
        }

        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public int ServiceCost { get; set; }
    }
}
