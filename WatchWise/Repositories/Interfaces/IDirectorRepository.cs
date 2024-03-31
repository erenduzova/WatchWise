using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IDirectorRepository
    {
        IQueryable<Director> GetAllDirectors();
        Director? GetDirectorById(int id);
        void AddDirector(Director director);
        Director? GetDirectorByName(string name);
        void DeleteDirector(Director director);
    }
}
