using AutoMapper;
using ServicesAPI.Application.Commands;
using ServicesAPI.Models;
using ServicesAPI.Queries;

namespace ServicesAPI.Application.Profiles
{
    public class ServiceProfiles :Profile
    {
        public ServiceProfiles()
        {
            CreateMap<Service, ServiceDTO>();
            CreateMap<ServiceDTO, Service>();
            CreateMap<CreateServiceCommand, Service>().ReverseMap();
            CreateMap<UpDateServiceCommand, Service>().ReverseMap();
          


        }
    }

    //public SuperHeroProfiles()
    //{
    //    CreateMap<CreateSuperHeroCommand, SuperHero>();
    //    CreateMap<UpDateSuperHeroCommand, SuperHero>();
    //    // CreateMap<DeleteSuperHeroCommand,int>();
    //}
}
