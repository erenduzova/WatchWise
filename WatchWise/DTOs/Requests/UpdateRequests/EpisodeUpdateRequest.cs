using System.ComponentModel.DataAnnotations;

namespace WatchWise.DTOs.Requests
{
    public class EpisodeUpdateRequest
    {
        public string? Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}

