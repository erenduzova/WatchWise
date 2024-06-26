﻿using System.ComponentModel.DataAnnotations;

namespace WatchWise.DTOs.Requests
{
    public class GenreRequest
    {

        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;
    }
}

