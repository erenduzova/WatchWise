using Microsoft.EntityFrameworkCore;
using WatchWise.Data;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;

namespace WatchWise.Repositories.Implementations
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly WatchWiseContext _context;

        public EpisodeRepository(WatchWiseContext context)
        {
            _context = context;
        }

        public IQueryable<Episode> GetAllEpisodes(bool includeUserWatchedEpisodes = false)
        {
            IQueryable<Episode> episodes = _context.Episodes;
            if (includeUserWatchedEpisodes)
            {
                episodes = episodes.Include(e => e.UserWatchedEpisodes);
            }
            return episodes;
        }

        public Episode? GetEpisodeById(long id, bool includeUserWatchedEpisodes = false)
        {
            IQueryable<Episode> episodes = _context.Episodes;
            if (includeUserWatchedEpisodes)
            {
                episodes = episodes.Include(e => e.UserWatchedEpisodes);
            }
            return episodes.FirstOrDefault(e => e.Id == id);
        }

        public void AddEpisode(Episode episode)
        {
            _context.Episodes.Add(episode);
            _context.SaveChanges();
        }

        public void UpdateEpisode(Episode episode)
        {
            _context.Update(episode);
            _context.SaveChanges();
        }
    }
}
