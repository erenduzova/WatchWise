using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
    public interface IUserWatchedEpisodeService
    {
        List<UserWatchedEpisodeResponse> GetAllUserWatchedEpisodeResponses();
        List<UserWatchedEpisodeResponse> GetUserWatchedEpisodeResponsesByUserId(long userId);
        List<UserWatchedEpisodeResponse> GetUserWatchedEpisodeResponsesByEpisodeId(long episodeId);
        int AddUserWatchedEpisode(UserWatchedEpisodeRequest userWatchedEpisodeRequest);
        int AddUserWatchedEpisode(long episodeId, long userId);
        int RemoveUserWatchedEpisode(UserWatchedEpisodeRequest userWatchedEpisodeRequest);
    }
}

