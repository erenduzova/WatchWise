using WatchWise.Models.CrossTables;

namespace WatchWise.Repositories.Interfaces
{
    public interface IUserWatchedEpisodeRepository
    {
        IQueryable<UserWatchedEpisode> GetAllUserWatchedEpisodes();
        IQueryable<UserWatchedEpisode> GetUserWatchedEpisodesByUserId(long userId);
        IQueryable<UserWatchedEpisode> GetUserWatchedEpisodesByEpisodeId(long episodeId);
        void AddUserWatchedEpisode(UserWatchedEpisode userWatchedEpisode);
        void DeleteUserWatchedEpisode(UserWatchedEpisode userWatchedEpisode);
    }
}

