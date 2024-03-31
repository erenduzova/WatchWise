using Microsoft.AspNetCore.Identity;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IStarRepository
    {
        IQueryable<Star> GetAllStars();
        Star? GetStarById(int id);
        void AddStar(Star star);
        Star? GetStarByName(string name);
        void DeleteStar(Star star);
    }
}
