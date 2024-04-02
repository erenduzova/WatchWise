using System;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Models.CrossTables;

namespace WatchWise.DTOs.Converters
{
	public class EpisodeConverter
	{
        public Episode Convert(EpisodeRequest episodeRequest)
        {
            Episode newEpisode = new()
            {
                MediaId = episodeRequest.MediaId,
                SeasonNum = episodeRequest.SeasonNum,
                EpisodeNum = episodeRequest.EpisodeNum,
                ReleaseDate = episodeRequest.ReleaseDate,
                Title = episodeRequest.Title,
                Description = episodeRequest.Description,
                Duration = episodeRequest.Duration,
                ViewCount = 0,
                Passive = false,
                UserWatchedEpisodes = new List<UserWatchedEpisode>()
            };
            return newEpisode;
        }

        public EpisodeResponse Convert(Episode episode)
        {
            EpisodeResponse episodeResponse = new()
            {
                Id = episode.Id,
                MediaId = episode.MediaId,
                SeasonNum = episode.SeasonNum,
                EpisodeNum = episode.EpisodeNum,
                ReleaseDate = episode.ReleaseDate,
                Title = episode.Title,
                Description = episode.Description,
                Duration = episode.Duration,
                ViewCount = episode.ViewCount,
                Passive = episode.Passive,
                UserWatchedEpisodes = new List<UserWatchedEpisode>()
            };
            if (episode.UserWatchedEpisodes != null)
            {
                episodeResponse.UserWatchedEpisodes = episode.UserWatchedEpisodes;
            }
            return episodeResponse;
        }

        public List<EpisodeResponse> Convert(List<Episode> episodes)
        {
            List<EpisodeResponse> episodeResponses = new();
            foreach (Episode episode in episodes)
            {
                episodeResponses.Add(Convert(episode));
            }
            return episodeResponses;
        }
    }
}

