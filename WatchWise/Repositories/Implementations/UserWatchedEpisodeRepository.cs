using WatchWise.Data;
using WatchWise.Models.CrossTables;
using WatchWise.Repositories.Interfaces;

namespace WatchWise.Repositories.Implementations
{
    public class UserWatchedEpisodeRepository : IUserWatchedEpisodeRepository
    {
        private readonly WatchWiseContext _context;

        public UserWatchedEpisodeRepository(WatchWiseContext context)
        {
            _context = context;
        }

        public IQueryable<UserWatchedEpisode> GetAllUserWatchedEpisodes()
        {
            IQueryable<UserWatchedEpisode> userWatchedEpisodes = _context.UserWatchedEpisodes;
            return userWatchedEpisodes;
        }

        public IQueryable<UserWatchedEpisode> GetUserWatchedEpisodesByUserId(long userId)
        {
            IQueryable<UserWatchedEpisode> userWatchedEpisodes = _context.UserWatchedEpisodes;
            return userWatchedEpisodes.Where(uw => uw.UserId == userId);
        }

        public IQueryable<UserWatchedEpisode> GetUserWatchedEpisodesByEpisodeId(long episodeId)
        {
            IQueryable<UserWatchedEpisode> userWatchedEpisodes = _context.UserWatchedEpisodes;
            return userWatchedEpisodes.Where(uw => uw.EpisodeId == episodeId);
        }

        public void AddUserWatchedEpisode(UserWatchedEpisode userWatchedEpisode)
        {
            _context.UserWatchedEpisodes.Add(userWatchedEpisode);
            _context.SaveChanges();
        }

        public void DeleteUserWatchedEpisode(UserWatchedEpisode userWatchedEpisode)
        {
            _context.UserWatchedEpisodes.Remove(userWatchedEpisode);
            _context.SaveChanges();
        }
    }
}

