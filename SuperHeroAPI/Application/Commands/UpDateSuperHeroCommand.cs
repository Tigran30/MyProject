using MediatR;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Commands
{
    public class UpDateSuperHeroCommand: IRequest<SuperHero>
    {
        public UpDateSuperHeroCommand(int Id, string Name, string FirstName, string LastName, string Place)
        {
            this.Id = Id;
            this.Name = Name;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Place = Place;
        }

        public int Id { get; }
        public string Name { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Place { get; }
    }
    
}
