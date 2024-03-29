using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchWise.Models.CrossTables;

namespace WatchWise.DTOs.Requests
{
	public class WatchWiseUserRequest
	{
        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string UserName { get; set; } = null!;

        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string Name { get; set; } = null!;

        [EmailAddress]
        [StringLength(100, MinimumLength = 5)]
        [Required]
        public string Email { get; set; } = null!;

        [Phone]
        [StringLength(30)]
        public string? PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Password { get; set; } = null!;
    }
}

