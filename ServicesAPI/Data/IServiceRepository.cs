using ServicesAPI.Application.Profiles;
using ServicesAPI.Models;
using ServicesAPI.Queries;

namespace ServicesAPI.Data
{
    public interface IServiceRepository
    {
        ServiceDTO CreateService(Service service);
        ServiceDTO DeleteService(int id);
        List<ServiceDTO> GetAllServices();
        ServiceDTO GetServicebyId(int id);
        ServiceDTO UpDateService(Service service);
    }
}