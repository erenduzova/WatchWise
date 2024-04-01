using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchWise.Models;

namespace WatchWise.DTOs.Responses
{
	public class GenreResponse
	{
        public short Id { get; set; }

        public string Name { get; set; } = null!;

        public List<MediaGenre>? MediaGenres { get; set; }
    }
}

