using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
	public interface IEpisodeService
	{
        List<EpisodeResponse> GetAllEpisodeResponses(bool includeUserWatchedEpisodes);
        EpisodeResponse? GetEpisodeResponseById(long id, bool includeUserWatchedEpisodes);
        void PostEpisode(EpisodeRequest episodeRequest);
        int UpdateEpisode(long id, EpisodeUpdateRequest episodeUpdateRequest);
        int DeleteEpisode(long id);
    }
}

