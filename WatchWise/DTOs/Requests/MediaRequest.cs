using System.ComponentModel.DataAnnotations;

namespace WatchWise.DTOs.Requests
{
    public class MediaRequest
    {
        [StringLength(200, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [StringLength(500, MinimumLength = 2)]
        public string? Description { get; set; }

        [Range(0, 10)]
        public float ImdbRating { get; set; }

        public bool Passive { get; set; }
    }
}

