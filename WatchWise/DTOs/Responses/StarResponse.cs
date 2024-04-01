using System;
using WatchWise.Models;

namespace WatchWise.DTOs.Responses
{
	public class StarResponse : PersonResponse
	{
        public List<MediaStar>? MediaStars { get; set; }
    }
}

