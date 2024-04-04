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

        private IQueryable<Director> IncludeRelatedObjects(IQueryable<Director> directors, bool includeMedias)
        {
            if (includeMedias)
            {
                directors = directors.Include(d => d.MediaDirectors);
            }
            return directors;
        }

        public IQueryable<Director> GetAllDirectors(bool includeMedias = false)
        {
            IQueryable<Director> directors = _context.Directors;
            directors = IncludeRelatedObjects(directors, includeMedias);
            return directors;
        }

        public Director? GetDirectorById(int id, bool includeMedias = false)
        {
            IQueryable<Director> directors = _context.Directors;
            directors = IncludeRelatedObjects(directors, includeMedias);
            return directors.FirstOrDefault(d => d.Id == id);
        }

        public Director? GetDirectorByName(string name, bool includeMedias = false)
        {
            IQueryable<Director> directors = _context.Directors;
            directors = IncludeRelatedObjects(directors, includeMedias);
            return directors.FirstOrDefault(d => d.Name == name);
        }

        public void AddDirector(Director director)
        {
            _context.Directors.Add(director);
            _context.SaveChanges();
        }

        public void UpdateDirector(Director director)
        {
            _context.Update(director);
            _context.SaveChanges();
        }

        public void DeleteDirector(Director director)
        {
            _context.Directors.Remove(director);
            _context.SaveChanges();
        }

    }
}
