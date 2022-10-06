using AutoMapper;
using SuperHeroAPI.Commands;
using SuperHeroAPI.Controllers;
using SuperHeroAPI.Models;
namespace SuperHeroAPI.Application.Commands.mapper
{
    public  class SuperHeroProfiles:Profile
    {
        public SuperHeroProfiles()
        {
            CreateMap<CreateSuperHeroCommand,SuperHero>();
            CreateMap<UpDateSuperHeroCommand,SuperHero>();
        }

        

    }
}
