using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IDirectorRepository
    {
        IQueryable<Director> GetAllDirectors(bool includeMedias = false);
        Director? GetDirectorById(int id, bool includeMedias = false);
        Director? GetDirectorByName(string name, bool includeMedias = false);
        void AddDirector(Director director);
        void DeleteDirector(Director director);
        void UpdateDirector(Director director);
    }
}
