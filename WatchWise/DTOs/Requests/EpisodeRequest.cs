﻿using System.ComponentModel.DataAnnotations;

namespace WatchWise.DTOs.Requests
{
    public class EpisodeRequest
    {
        public int MediaId { get; set; }

        [Range(0, byte.MaxValue)]
        public byte SeasonNum { get; set; }

        [Range(0, 366)]
        public short EpisodeNum { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Title { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        public TimeSpan Duration { get; set; }
    }
}

