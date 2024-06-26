﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchWise.Models.CrossTables;

namespace WatchWise.Models
{
    public class Media
    {

        public int Id { get; set; }

        [StringLength(200, MinimumLength = 2)]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; } = "";

        [StringLength(500, MinimumLength = 2)]
        [Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; }

        [Range(0, 10)]
        public float ImdbRating { get; set; }

        public bool Passive { get; set; }

        public virtual List<MediaGenre>? MediaGenres { get; set; }
        public virtual List<MediaStar>? MediaStars { get; set; }
        public virtual List<MediaDirector>? MediaDirectors { get; set; }
        public virtual List<MediaRestriction>? MediaRestrictions { get; set; }
        public virtual List<UserFavorite>? UserFavorites { get; set; }

    }
}

