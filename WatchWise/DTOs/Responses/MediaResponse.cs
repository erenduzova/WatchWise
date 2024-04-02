using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchWise.Models;
using WatchWise.Models.CrossTables;

namespace WatchWise.DTOs.Responses
{
	public class MediaResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string? Description { get; set; }

        public float ImdbRating { get; set; }

        public bool Passive { get; set; }

        public List<MediaGenre>? MediaGenres { get; set; }
        public List<MediaStar>? MediaStars { get; set; }
        public List<MediaDirector>? MediaDirectors { get; set; }
        public List<MediaRestriction>? MediaRestrictions { get; set; }
        public List<UserFavorite>? UserFavorites { get; set; }
    }
}

