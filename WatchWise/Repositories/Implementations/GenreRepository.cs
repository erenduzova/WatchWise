using WatchWise.Data;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;

namespace WatchWise.Repositories.Implementations
{
    public class GenreRepository : IGenreRepository
    {
        private readonly WatchWiseContext _context;

        public GenreRepository(WatchWiseContext context)
        {
            _context = context;
        }

        public IQueryable<Genre> GetAllGenres()
        {
            return _context.Genres;
        }

        public Genre? GetGenreById(short id)
        {
            return _context.Genres.FirstOrDefault(g => g.Id == id);
        }

        public void AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public Genre? GetGenreByName(string name)
        {
            return _context.Genres.FirstOrDefault(g => g.Name == name);
        }

    }
}
