using System;
namespace WatchWise.DTOs.Requests
{
	public class UserWatchedEpisodeRequest
    {
        public long UserId { get; set; }
        public long EpisodeId { get; set; }
    }
}

