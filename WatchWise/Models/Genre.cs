﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchWise.Models
{
	public class Genre
	{

        public short Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength =2)]
        [Column(TypeName = "nvarchar(50)")]
        public required string Name { get; set; }

    }
}

