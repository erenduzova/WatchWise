using System.ComponentModel.DataAnnotations;

namespace WatchWise.DTOs.Requests
{
    public class PlanRequest
    {
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Range(0, float.MaxValue)]
        public float Price { get; set; }

        [StringLength(20, MinimumLength = 2)]
        public string MaxResolution { get; set; } = null!;
    }
}

