using MediatR;
using ServicesAPI.Application.Profiles;

namespace ServicesAPI.Queries
{
    public class GetServicebyIDQuery: IRequest<ServiceDTO>
    {
       
        public int ID { set; get; }

        public GetServicebyIDQuery(int iD)
        {
            ID = iD;
        }
    }
}
