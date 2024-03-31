using Microsoft.EntityFrameworkCore;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IEpisodeRepository
    {
        IQueryable<Episode> GetAllEpisodes();
        Episode? GetEpisodeById(long id);
        void AddEpisode(Episode episode);
        void UpdateEpisode(Episode episode);
    }
}