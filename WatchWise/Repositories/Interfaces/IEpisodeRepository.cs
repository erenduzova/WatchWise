using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IEpisodeRepository
    {
        IQueryable<Episode> GetAllEpisodes(bool includeUserWatchedEpisodes = false);
        Episode? GetEpisodeById(long id, bool includeUserWatchedEpisodes = false);
        void AddEpisode(Episode episode);
        void UpdateEpisode(Episode episode);
    }
}