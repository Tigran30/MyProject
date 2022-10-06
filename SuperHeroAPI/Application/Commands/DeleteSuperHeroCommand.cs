using MediatR;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Commands
{
    public class DeleteSuperHeroCommand : IRequest<SuperHero>
    {
        public DeleteSuperHeroCommand(int Id)
        {
            this.Id = Id;
           
        }

        public int Id { get; set; }
    
    }



}
