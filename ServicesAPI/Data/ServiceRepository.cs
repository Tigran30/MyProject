using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesAPI.Application.Profiles;
using ServicesAPI.Models;
using ServicesAPI.Queries;

namespace ServicesAPI.Data
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ServiceCatalogContext _context;
        private readonly IMapper _mapper;

        public ServiceRepository(ServiceCatalogContext context,IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }


        public List<ServiceDTO> GetAllServices()
        {
            var a=_mapper.Map<IEnumerable<ServiceDTO>>(_context.Services.ToList()).ToList();
            return a;

           
        }
        public ServiceDTO GetServicebyId(int id)
        {
            var result = _context.Services.Find(id);
            if (result == null)
                throw ArgumentNullException();
            var resultdto=_mapper.Map<ServiceDTO>(result);
            return resultdto;
        }


        public ServiceDTO CreateService(Service service)
        {

            if (service == null) throw ArgumentNullException();
            service.CreatedTime = DateTime.Now;
            _context.Services.Add(service);
            _context.SaveChanges();
            return _mapper.Map<ServiceDTO>(service);
        }
        public ServiceDTO UpDateService(Service service)
        {
            Service updatedservice = _context.Services.Find(service.Id);
            if (updatedservice == null) throw ArgumentNullException();
            updatedservice.UpdatedTime = DateTime.Now;
            updatedservice.ServiceName = service.ServiceName;
            updatedservice.ServiceCost = service.ServiceCost;
            _context.SaveChanges();
            return _mapper.Map<ServiceDTO>(updatedservice);
        }
        public ServiceDTO DeleteService(int id)
        {
            var result = _context.Services.Find(id);
            if (result == null)
                throw ArgumentNullException();
            _context.Services.Remove(result);
            _context.SaveChanges();
            return _mapper.Map<ServiceDTO>(result);
        }

        private Exception ArgumentNullException()
        {
            throw new NotImplementedException();
        }
    }
}
