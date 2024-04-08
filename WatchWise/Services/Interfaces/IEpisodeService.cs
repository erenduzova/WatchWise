using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
	public interface IEpisodeService
	{
        List<EpisodeResponse> GetAllEpisodeResponses();
        EpisodeResponse? GetEpisodeResponseById(long id);
        void PostEpisode(EpisodeRequest episodeRequest);
        int UpdateEpisode(long id, EpisodeUpdateRequest episodeUpdateRequest);
        int DeleteEpisode(long id);
        int Watch(long id, long userId);
    }
}

