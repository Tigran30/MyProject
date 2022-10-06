using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Commands;
using SuperHeroAPI.Models;
using System.Diagnostics.Contracts;

namespace SuperHeroAPI.Data
{
    public interface ISuperHeroRepository
    {
        void SaveChanges();
        List<SuperHero> GetAllSuperHeroes();
        SuperHero GetSuperHeroById(int id);
        Task CreateSuperHero(SuperHero hero);
        SuperHero UpdateSuperHero(SuperHero newSuperHeroCommand);
        void DeleteSuperHero(int id);
    }
    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly DataContext _context;
    

        public SuperHeroRepository(DataContext context)
        {
         
            this._context = context;
        }

        public  async Task CreateSuperHero(SuperHero hero)
        {
            if (hero == null) 
                throw new ArgumentNullException();
            _context.Add(hero);
            await _context.SaveChangesAsync();
        }

        public  void DeleteSuperHero(int id)
        {
            var hero = _context.SuperHeroes.Find(id);
            if (hero == null) throw ArgumentNullException();
            _context.Remove(hero);          
        }
        public SuperHero UpdateSuperHero(SuperHero request)
        {
            var result = _context.SuperHeroes.Find(request.Id);
            if (result == null) throw ArgumentNullException();
            result.Name=request.Name;
            result.FirstName = request.FirstName;
            result.LastName = request.LastName;
            result.Place = request.Place;
            return result;
        }

        public List<SuperHero> GetAllSuperHeroes()
        {
            return _context.SuperHeroes.ToList();
        }

        public SuperHero GetSuperHeroById(int id)
        {
            var hero = _context.SuperHeroes.Find(id);
            if (hero == null) throw ArgumentNullException();
            return hero;
        }


        public async void SaveChanges()
        {
             int save= _context.SaveChanges();
            if(save<1)               
           throw DbUpdateException();

        }

        private Exception DbUpdateException()
        {
            throw new NotImplementedException();
        }

        private Exception ArgumentNullException()
        {
            throw new NotImplementedException();
        }

        
    }
}
