using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchWise.DTOs.Requests
{
	public class RestrictionRequest
    {
        public byte Id { get; set; }

        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; } = null!;
    }
}

