using MediatR;
using ServicesAPI.Application.Profiles;

namespace ServicesAPI.Application.Commands
{
    public class DeleteServiceCommand : IRequest<ServiceDTO>
    {
        public DeleteServiceCommand(int iD)
        {
            ID = iD;
        }

        public int ID { set; get; }

    }
}
