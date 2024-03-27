using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchWise.Models.CrossTables
{
	public class UserWatchedEpisode
	{
        public long UserId { get; set; }

        public long EpisodeId { get; set; }

        [ForeignKey("UserId")]
        public WatchWiseUser? WatchWiseUser { get; set; }

        [ForeignKey("EpisodeId")]
        public Episode? Episode { get; set; }
    }
}
