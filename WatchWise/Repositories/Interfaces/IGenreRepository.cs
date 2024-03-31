using Microsoft.EntityFrameworkCore;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        IQueryable<Genre> GetAllGenres(bool includeMediaGenres = false);
        Genre? GetGenreById(short id, bool includeMediaGenres = false);
        Genre? GetGenreByName(string name, bool includeMediaGenres = false);
        void AddGenre(Genre genre);
    }
}