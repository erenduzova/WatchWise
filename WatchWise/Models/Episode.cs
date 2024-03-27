using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchWise.Models.CrossTables;

namespace WatchWise.Models
{
	public class Episode
	{
        public long Id { get; set; }
        
        public int MediaId { get; set; }
        [ForeignKey("MediaId")]
        public Media? Media { get; set; }

        [Range(0, byte.MaxValue)]
        public byte SeasonNum { get; set; }

        [Range(0, 366)]
        public short EpisodeNum { get; set; }

        public DateTime ReleaseDate { get; set; }

        public required string Title { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; }

        public TimeSpan Duration { get; set; }

        public long ViewCount { get; set; }

        public bool Passive { get; set; }

        public List<UserWatchedEpisode>? UserWatchedEpisodes;
    }
}

