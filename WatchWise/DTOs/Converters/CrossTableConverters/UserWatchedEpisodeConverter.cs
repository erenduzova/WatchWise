using System;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models.CrossTables;

namespace WatchWise.DTOs.Converters
{
	public class UserWatchedEpisodeConverter
	{
        public UserWatchedEpisode Convert(UserWatchedEpisodeRequest userWatchedEpisodeRequest)
        {
            UserWatchedEpisode newUserWatchedEpisode = new()
            {
                UserId = userWatchedEpisodeRequest.UserId,
                EpisodeId = userWatchedEpisodeRequest.EpisodeId
            };
            return newUserWatchedEpisode;
        }

        public UserWatchedEpisodeResponse Convert(UserWatchedEpisode userWatchedEpisode)
        {
            UserWatchedEpisodeResponse userWatchedEpisodeResponse = new()
            {
                UserId = userWatchedEpisode.UserId,
                EpisodeId = userWatchedEpisode.EpisodeId
            };
            return userWatchedEpisodeResponse;
        }

        public List<UserWatchedEpisodeResponse> Convert(List<UserWatchedEpisode> userWatchedEpisodes)
        {
            List<UserWatchedEpisodeResponse> userWatchedEpisodeResponses = new();
            foreach (UserWatchedEpisode userWatchedEpisode in userWatchedEpisodes)
            {
                userWatchedEpisodeResponses.Add(Convert(userWatchedEpisode));
            }
            return userWatchedEpisodeResponses;
        }

    }
}

