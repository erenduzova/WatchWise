using System;
using WatchWise.Models;

namespace WatchWise.DTOs.Responses
{
	public class DirectorResponse : PersonResponse
	{
        public List<MediaDirector>? MediaDirectors { get; set; }
    }
}

