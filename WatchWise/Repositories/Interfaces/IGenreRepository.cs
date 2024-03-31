using Microsoft.EntityFrameworkCore;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        IQueryable<Genre> GetAllGenres();
        Genre? GetGenreById(short id);
        void AddGenre(Genre genre);
        Genre? GetGenreByName(string name);
    }
}