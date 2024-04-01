using Microsoft.AspNetCore.Identity;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IStarRepository
    {
        IQueryable<Star> GetAllStars(bool includeMedias = false);
        Star? GetStarById(int id, bool includeMedia = false);
        Star? GetStarByName(string name, bool includeMedia = false);
        void AddStar(Star star);
        void DeleteStar(Star star);
        void UpdateStar(Star star);
    }
}
