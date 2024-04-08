using System.ComponentModel.DataAnnotations;

namespace WatchWise.DTOs.Requests
{
    public class RestrictionRequest
    {
        public byte Id { get; set; }

        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; } = null!;
    }
}

