using Microsoft.EntityFrameworkCore;
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

        public IQueryable<Genre> GetAllGenres(bool includeMedia = false)
        {
            IQueryable<Genre> genres = _context.Genres;
            if (includeMedia)
            {
                genres = genres.Include(g => g.MediaGenres);
            }
            return genres;
        }

        public Genre? GetGenreById(short id, bool includeMedia = false)
        {
            IQueryable<Genre> genres = _context.Genres;
            if (includeMedia)
            {
                genres = genres.Include(g => g.MediaGenres);
            }
            return genres.FirstOrDefault(g => g.Id == id);
        }

        public Genre? GetGenreByName(string name, bool includeMedia = false)
        {
            IQueryable<Genre> genres = _context.Genres;
            if (includeMedia)
            {
                genres = genres.Include(g => g.MediaGenres);
            }
            return genres.FirstOrDefault(g => g.Name == name);
        }

        public void AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void UpdateGenre(Genre genre)
        {
            _context.Genres.Update(genre);
            _context.SaveChanges();
        }
    }
}
