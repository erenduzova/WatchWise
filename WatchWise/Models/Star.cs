using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WatchWise.Models
{
    public class Star : Person
	{
        public virtual List<MediaStar>? MediaStars { get; set; }
    }
}

