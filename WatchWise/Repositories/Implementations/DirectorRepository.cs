using Microsoft.EntityFrameworkCore;
using WatchWise.Data;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;

namespace WatchWise.Repositories.Implementations
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly WatchWiseContext _context;

        public DirectorRepository(WatchWiseContext context)
        {
            _context = context;
        }

        public IQueryable<Director> GetAllDirectors()
        {
            return _context.Directors;
        }

        public Director? GetDirectorById(int id)
        {
            return _context.Directors.FirstOrDefault(d => d.Id == id);
        }

        public void AddDirector(Director director)
        {
            _context.Directors.Add(director);
            _context.SaveChanges();
        }

        public Director? GetDirectorByName(string name)
        {
            return _context.Directors.FirstOrDefault(d => d.Name == name);
        }
        public void DeleteDirector(Director director)
        {
            _context.Directors.Remove(director);
            _context.SaveChanges();
        }
    }
}
