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

        public IQueryable<Episode> GetAllEpisodes()
        {
            return _context.Episodes;
        }

        public Episode? GetEpisodeById(long id)
        {
            return _context.Episodes.FirstOrDefault(e => e.Id == id);
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
