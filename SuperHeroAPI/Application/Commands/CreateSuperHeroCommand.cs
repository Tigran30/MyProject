using MediatR;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Commands
{
    // public record InsertSuperHeroCommand(string Name,string FirstName, string LastName,string Place): IRequest<SuperHero>;
    public class CreateSuperHeroCommand :IRequest<bool>
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Place { get; set; }


        public CreateSuperHeroCommand(string name, string firstName, string lastName, string place)
        {
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Place = place;
        }
    }
    
}
