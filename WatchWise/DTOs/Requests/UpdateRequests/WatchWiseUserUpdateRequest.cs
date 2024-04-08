using System.ComponentModel.DataAnnotations;

namespace WatchWise.DTOs.Requests
{
    public class WatchWiseUserUpdateRequest
    {
        [StringLength(100, MinimumLength = 2)]
        public string? UserName { get; set; }

        [EmailAddress]
        [StringLength(100, MinimumLength = 5)]
        public string? Email { get; set; }

        [Phone]
        [StringLength(30)]
        public string? PhoneNumber { get; set; }
    }
}

