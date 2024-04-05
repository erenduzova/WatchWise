using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models.CrossTables;

namespace WatchWise.Services.Interfaces
{
	public interface IUserWatchedEpisodeService
	{
        List<UserWatchedEpisodeResponse> GetAllUserWatchedEpisodeResponses();
        List<UserWatchedEpisodeResponse> GetUserWatchedEpisodeResponsesByUserId(long userId);
        List<UserWatchedEpisodeResponse> GetUserWatchedEpisodeResponsesByEpisodeId(long episodeId);
        void AddUserWatchedEpisode(UserWatchedEpisodeRequest userWatchedEpisodeRequest);
        void RemoveUserWatchedEpisode(UserWatchedEpisode userWatchedEpisode);
    }
}

