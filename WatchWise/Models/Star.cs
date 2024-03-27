using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WatchWise.Models
{
    public class Star : Person
	{
        public List<MediaStar>? MediaStars { get; set; }
    }
}

